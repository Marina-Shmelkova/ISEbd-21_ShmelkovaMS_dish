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
		private DataListSingleton()
		{
			Components = new List<Component>();
			Orders = new List<Order>();
			Dishs = new List<Dish>();
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
