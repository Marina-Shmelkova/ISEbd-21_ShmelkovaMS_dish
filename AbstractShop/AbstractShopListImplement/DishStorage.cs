using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractShopListImplement
{
	public class DishStorage : IDishStorage
	{
		private readonly DataListSingleton source;
		public DishStorage()
		{
			source = DataListSingleton.GetInstance();
		}
		public List<DishViewModel> GetFullList()
		{
			List<DishViewModel> result = new List<DishViewModel>();
			foreach (var component in source.Products)
			{
				result.Add(CreateModel(component));
			}
			return result;
		}
		public List<DishViewModel> GetFilteredList(DishBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			List<DishViewModel> result = new List<DishViewModel>();
			foreach (var product in source.Products)
			{
				if (product.DishName.Contains(model.DishName))
				{
					result.Add(CreateModel(product));
				}
			}
			return result;
		}
		public DishViewModel GetElement(DishBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			foreach (var product in source.Products)
			{
				if (product.Id == model.Id || product.DishName == model.DishName)
				{
					return CreateModel(product);
				}
			}
			return null;
		}
		public void Insert(DishBindingModel model)
		{
			Dish tempProduct = new Dish { Id = 1, DishComponents = new Dictionary<int, int>() };
			foreach (var product in source.Products)
			{
				if (product.Id >= tempProduct.Id)
				{
					tempProduct.Id = product.Id + 1;
				}
			}
			source.Products.Add(CreateModel(model, tempProduct));
		}
		public void Update(DishBindingModel model)
		{
			Dish tempProduct = null;
			foreach (var product in source.Products)
			{
				if (product.Id == model.Id)
				{
					tempProduct = product;
				}
			}
			if (tempProduct == null)
			{
				throw new Exception("Элемент не найден");
			}
			CreateModel(model, tempProduct);
		}
		public void Delete(DishBindingModel model)
		{
			for (int i = 0; i < source.Products.Count; ++i)
			{
				if (source.Products[i].Id == model.Id)
				{
					source.Products.RemoveAt(i);
					return;
				}
			}
			throw new Exception("Элемент не найден");
		}
		private Dish CreateModel(DishBindingModel model, Dish product)
		{
			product.DishName = model.DishName;
			product.Price = model.Price;
			// удаляем убранные
			foreach (var key in product.DishComponents.Keys.ToList())
			{
				if (!model.DishComponents.ContainsKey(key))
				{
					product.DishComponents.Remove(key);
				}
			}
			// обновляем существуюущие и добавляем новые
			foreach (var component in model.DishComponents)
			{
				if (product.DishComponents.ContainsKey(component.Key))
				{
					product.DishComponents[component.Key] = model.DishComponents[component.Key].Item2;
				}
				else
				{
					product.DishComponents.Add(component.Key, model.DishComponents[component.Key].Item2);
				}
			}
			return product;
		}
		private DishViewModel CreateModel(Dish product)
		{
			// требуется дополнительно получить список компонентов для изделия с названиями и их количество
			Dictionary<int, (string, int)> productComponents = new Dictionary<int, (string, int)>();
			foreach (var pc in product.DishComponents)
			{
				string componentName = string.Empty;
				foreach (var component in source.Components)
				{
					if (pc.Key == component.Id)
					{
						componentName = component.ComponentName;
						break;
					}
				}
				productComponents.Add(pc.Key, (componentName, pc.Value));
			}
			return new DishViewModel
			{
				Id = product.Id,
				DishName = product.DishName,
				Price = product.Price,
				DishComponents = productComponents
			};
		}
	}

}
