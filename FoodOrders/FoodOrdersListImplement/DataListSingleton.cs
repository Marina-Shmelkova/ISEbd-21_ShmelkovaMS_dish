using FoodOrdersListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersListImplement
{
	public class DataListSingleton
	{
		private static DataListSingleton instance;
		public List<Component> Components { get; set; }
		public List<Order> Orders { get; set; }
		public List<Dish> Dishs { get; set; }
		public List<Storehouse> Storehouses { get; set; }
		public List<Client> Clients { get; set; }
		private DataListSingleton()
		{
			Components = new List<Component>();
			Orders = new List<Order>();
			Dishs = new List<Dish>();
			Clients = new List<Client>();
			Storehouses = new List<Storehouse>();
		}
		public static DataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new DataListSingleton();
			}
			return instance;
		}
	}
}
