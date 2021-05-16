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
		private readonly string ClientFileName = "Client.xml";

		private readonly string StorehouseFileName = "Storehouse.xml";
		private readonly string ImplementerFileName = "Implementer.xml";
		public List<Component> Components { get; set; }
		public List<Order> Orders { get; set; }
		public List<Dish> Dishs { get; set; }
		public List<Client> Clients { get; set; }
		public List<Implementer> Implementers { get; set; }
		public List<Storehouse> Storehouses { get; set; }
		private FileDataListSingleton()
		{
			Components = LoadComponents();
			Orders = LoadOrders();
			Dishs = LoadDishs();
			Clients = LoadClients();
			Implementers = LoadImplementers();
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
			SaveClients();
			SaveImplementers();
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
						ClientId = Convert.ToInt32(elem.Element("ClientId").Value),
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
		private List<Client> LoadClients()
		{
			var list = new List<Client>();
			if (File.Exists(ClientFileName))
			{
				XDocument xDocument = XDocument.Load(ClientFileName);
				var xElements = xDocument.Root.Elements("Client").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Client
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ClientFIO = elem.Element("ClientFIO").Value,
						Email = elem.Element("Email").Value,
						Password = elem.Element("Password").Value,
					});
				}
			}
			return list;
		}
		private List<Implementer> LoadImplementers()
		{
			var list = new List<Implementer>();
			if (File.Exists(ImplementerFileName))
			{
				XDocument xDocument = XDocument.Load(ImplementerFileName);
				var xElements = xDocument.Root.Elements("Implementer").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Implementer
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ImplementerFIO = elem.Element("ImplementerFIO").Value,
						WorkingTime = Convert.ToInt32(elem.Element("WorkingTime").Value),
						PauseTime = Convert.ToInt32(elem.Element("PauseTime").Value),
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
					new XElement("ClientId", order.ClientId),
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
		private void SaveClients()
		{
			if (Clients != null)
			{
				var xElement = new XElement("Clients");
				foreach (var client in Clients)
				{
					xElement.Add(new XElement("Client",
					new XAttribute("Id", client.Id),
					new XElement("ClientFIO", client.ClientFIO),
					new XElement("Email", client.Email),
					new XElement("Password", client.Password)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ClientFileName);
			}
		}
		private void SaveImplementers()
		{
			if (Implementers != null)
			{
				var xElement = new XElement("Implementers");
				foreach (var implementer in Implementers)
				{
					xElement.Add(new XElement("Implementer",
					new XAttribute("Id", implementer.Id),
					new XElement("ImplementerFIO", implementer.ImplementerFIO),
					new XElement("WorkingTime", implementer.WorkingTime),
					new XElement("PauseTime", implementer.PauseTime)));
				}
				XDocument xDocument = new XDocument(xElement);
				xDocument.Save(ImplementerFileName);
			}
		}
	}
}
