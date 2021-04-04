using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using FoodOrdersListImplement;
using FoodOrdersBusinessLogic.Enums;
using FoodOrdersFileImplement.Models;

namespace FoodOrdersFileImplement.Implements
{
	public class FileDataListSingleton
	{
		private static FileDataListSingleton instance;

		private readonly string ComponentFileName = "Component.xml";

		private readonly string OrderFileName = "Order.xml";

		private readonly string DishFileName = "Dish.xml";

		private readonly string StorehouseFileName = "Storehouse.xml";
		public List<Component> Components { get; set; }
		public List<Order> Orders { get; set; }
		public List<Dish> Dishs { get; set; }
		public List<Storehouse> Storehouses { get; set; }
		private FileDataListSingleton()
		{
			Components = LoadComponents();
			Orders = LoadOrders();
			Dishs = LoadDishs();
			Storehouses = LoadStorehouses();
		}
		public static FileDataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new FileDataListSingleton();
			}
			return instance;
		}
		~FileDataListSingleton()
		{
			SaveComponents();
			SaveOrders();
			SaveDishs();
			SaveStorehouses();
		}
		private List<Component> LoadComponents()
		{
			var list = new List<Component>();
			if (File.Exists(ComponentFileName))
			{
				XDocument xDocument = XDocument.Load(ComponentFileName);
				var xElements = xDocument.Root.Elements("Component").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Component
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ComponentName = elem.Element("ComponentName").Value
					});
				}
			}
			return list;
		}
		private List<Order> LoadOrders()
		{
			var list = new List<Order>();
			if (File.Exists(OrderFileName))
			{
				XDocument xDocument = XDocument.Load(OrderFileName);
				var xElements = xDocument.Root.Elements("Order").ToList();
				foreach (var elem in xElements)
				{
					OrderStatus status = 0;
					
					switch (elem.Element("Status").Value)
					{
						case "Принят":
							status = OrderStatus.Принят;
							break;
						case "Выполняется":
							status = OrderStatus.Выполняется;
							break;
						case "Готов":
							status = OrderStatus.Готов;
							break;
						case "Оплачен":
							status = OrderStatus.Оплачен;
							break;
					}
					DateTime? dateImplement = null;
					if (elem.Element("DateImplement").Value != "")
					{
						dateImplement = Convert.ToDateTime(elem.Element("DateImplement").Value);
					}
					list.Add(new Order
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						DishId = Convert.ToInt32(elem.Element("DishId").Value),
						Count = Convert.ToInt32(elem.Element("Count").Value),
						Sum = Convert.ToDecimal(elem.Element("Sum").Value),
						Status = status,
						DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
						DateImplement = dateImplement
					});
				}
			}
			return list;
		}
		private List<Dish> LoadDishs()
		{
			var list = new List<Dish>();
			if (File.Exists(DishFileName))
			{
				XDocument xDocument = XDocument.Load(DishFileName);
				var xElements = xDocument.Root.Elements("Dish").ToList();
				foreach (var elem in xElements)
				{
					var prodComp = new Dictionary<int, int>();
					foreach (var component in elem.Element("DishComponents").Elements("DishComponent").ToList())
					{
						prodComp.Add(Convert.ToInt32(component.Element("Key").Value), 
						Convert.ToInt32(component.Element("Value").Value));
					}
					list.Add(new Dish
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						DishName = elem.Element("DishName").Value,
						Price = Convert.ToDecimal(elem.Element("Price").Value),
						DishComponents = prodComp
					});
				}
			}
			return list;
		}
		private void SaveComponents()
		{
			if (Components != null)
			{
				var xElement = new XElement("Components");
				foreach (var component in Components)
				{
					xElement.Add(new XElement("Component",
					new XAttribute("Id", component.Id),
					new XElement("ComponentName", component.ComponentName)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ComponentFileName);
			}
		}
		private List<Storehouse> LoadStorehouses()
		{
			var list = new List<Storehouse>();
			if (File.Exists(StorehouseFileName))
			{
				XDocument xDocument = XDocument.Load(StorehouseFileName);
				var xElements = xDocument.Root.Elements("Storehouse").ToList();
				foreach (var elem in xElements)
				{
					var houseComp = new Dictionary<int, int>();
					foreach (var component in
					elem.Element("StorehouseComponents").Elements("StorehouseComponent").ToList())
					{
						houseComp.Add(Convert.ToInt32(component.Element("Key").Value),
						Convert.ToInt32(component.Element("Value").Value));
					}
					list.Add(new Storehouse
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						StorehouseName = elem.Element("StorehouseName").Value,
						Responsible = elem.Element("Responsible").Value,
						DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
						StorehouseComponents = houseComp
					});
				}
			}
			return list;
		}
		private void SaveOrders()
		{
			if (Orders != null)
			{
				var xElement = new XElement("Orders");
				foreach (var order in Orders)
				{
					xElement.Add(new XElement("Order",
					new XAttribute("Id", order.Id),
					new XElement("DishId", order.DishId),
					new XElement("Count", order.Count),
					new XElement("Sum", order.Sum),
					new XElement("Status", order.Status),
					new XElement("DateCreate", order.DateCreate),
					new XElement("DateImplement", order.DateImplement)));

				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(OrderFileName);
			}
		}
		private void SaveDishs()
		{
			if (Dishs != null)
			{
				var xElement = new XElement("Dishs");
				foreach (var dish in Dishs)
				{
					var compElement = new XElement("DishComponents");
					foreach (var component in dish.DishComponents)
					{
						compElement.Add(new XElement("DishComponent",
						new XElement("Key", component.Key),
						new XElement("Value", component.Value)));
					}
					xElement.Add(new XElement("Dish",
					new XAttribute("Id", dish.Id),
					new XElement("DishName", dish.DishName),
					new XElement("Price", dish.Price),
					compElement));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(DishFileName);
			}
		}
		private void SaveStorehouses()
		{
			if (Storehouses != null)
			{
				var xElement = new XElement("Storehouses");
				foreach (var house in Storehouses)
				{
					var compElement = new XElement("StorehouseComponents");
					foreach (var component in house.StorehouseComponents)
					{
						compElement.Add(new XElement("StorehouseComponent",
						new XElement("Key", component.Key),
						new XElement("Value", component.Value)));
					}
					xElement.Add(new XElement("Storehouse",
					new XAttribute("Id", house.Id),
					new XElement("StorehouseName", house.StorehouseName),
					new XElement("Responsible", house.Responsible),
					new XElement("DateCreate", house.DateCreate),
					compElement));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(StorehouseFileName);
			}
		}
	}
}
