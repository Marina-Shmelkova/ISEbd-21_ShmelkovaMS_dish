using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersListImplement
{
	/// <summary>
	/// Изделие, изготавливаемое в магазине
	/// </summary>
	public class Dish
	{
		public int Id { get; set; }
		public string DishName { get; set; }
		public decimal Price { get; set; }
		public Dictionary<int, int> DishComponents { get; set; }
	}
}
