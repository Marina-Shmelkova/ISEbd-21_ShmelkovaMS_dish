using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrdersFileImplement.Implements
{
	public class DishStorage : IDishStorage
	{
		private readonly FileDataListSingleton source;
		public DishStorage()
		{
			source = FileDataListSingleton.GetInstance();
		}
		public List<DishViewModel> GetFullList()
		{
			return source.Dishs
			.Select(CreateModel)
			.ToList();
		}
		public List<DishViewModel> GetFilteredList(DishBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return source.Dishs
			.Where(rec => rec.DishName.Contains(model.DishName))
			.Select(CreateModel)
			.ToList();
		}
		public DishViewModel GetElement (DishBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			var dish = source.Dishs
			.FirstOrDefault(rec => rec.DishName == model.DishName || rec.Id == model.Id);
			return dish != null ? CreateModel(dish) : null;
		}
		public void Insert(DishBindingModel model)
		{
			int maxId = source.Dishs.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
			var element = new Dish { Id = maxId + 1, DishComponents = new Dictionary<int, int>() };
			source.Dishs.Add(CreateModel(model, element));
		}
		public void Update(DishBindingModel model)
		{
			var element = source.Dishs.FirstOrDefault(rec => rec.Id == model.Id);
			if (element == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, element);
		}
		public void Delete(DishBindingModel model)
		{
			Dish element = source.Dishs.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				source.Dishs.Remove(element);
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}
		private Dish CreateModel(DishBindingModel model, Dish dish)
		{
			dish.DishName = model.DishName;
			dish.Price = model.Price;
			// удаляем убранные
			foreach (var key in dish.DishComponents.Keys.ToList())
			{
				if (!model.DishComponents.ContainsKey(key))
				{
					dish.DishComponents.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
			foreach (var component in model.DishComponents)
			{
				if (dish.DishComponents.ContainsKey(component.Key))
				{
					dish.DishComponents[component.Key] = model.DishComponents[component.Key].Item2;
				}
				else
				{
					dish.DishComponents.Add(component.Key, model.DishComponents[component.Key].Item2);
				}
			}
			return dish;
		}
		private DishViewModel CreateModel(Dish dish)
		{
			return new DishViewModel
			{
				Id = dish.Id,
				DishName = dish.DishName,
				Price = dish.Price,
				DishComponents = dish.DishComponents.ToDictionary(recPC => recPC.Key, recPC =>(source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
			};
		}
	}
}
