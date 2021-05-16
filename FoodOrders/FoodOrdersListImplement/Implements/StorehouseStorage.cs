using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrdersListImplement.Implements
{
    public class StorehouseStorage : IStorehouseStorage
    {
        private readonly DataListSingleton source;
        public StorehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            List<StorehouseViewModel> result = new List<StorehouseViewModel>();
            foreach (var component in source.Storehouses)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<StorehouseViewModel> result = new List<StorehouseViewModel>();
            foreach (var house in source.Storehouses)
            {
                if (house.StorehouseName.Contains(model.StorehouseName))
                {
                    result.Add(CreateModel(house));
                }
            }
            return result;
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var house in source.Storehouses)
            {
                if (house.Id == model.Id || house.StorehouseName == model.StorehouseName)
                {
                    return CreateModel(house);
                }
            }
            return null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            Storehouse tempStorehouse = new Storehouse { Id = 1, StorehouseComponents = new Dictionary<int, int>() };
            foreach (var house in source.Storehouses)
            {
                if (house.Id >= tempStorehouse.Id)
                {
                    tempStorehouse.Id = house.Id + 1;
                }
            }
            source.Storehouses.Add(CreateModel(model, tempStorehouse));
        }
        public void Update(StorehouseBindingModel model)
        {
            Storehouse tempStorehouse = null;
            foreach (var house in source.Storehouses)
            {
                if (house.Id == model.Id)
                {
                    tempStorehouse = house;
                }
            }
            if (tempStorehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempStorehouse);
        }
        public void Delete(StorehouseBindingModel model)
        {
            for (int i = 0; i < source.Storehouses.Count; ++i)
            {
                if (source.Storehouses[i].Id == model.Id)
                {
                    source.Storehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse house)
        {
            house.StorehouseName = model.StorehouseName;
            house.Responsible = model.Responsible;
            house.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in house.StorehouseComponents.Keys.ToList())
            {
                if (!model.StorehouseComponents.ContainsKey(key))
                {
                    house.StorehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.StorehouseComponents)
            {
                if (house.StorehouseComponents.ContainsKey(component.Key))
                {
                    house.StorehouseComponents[component.Key] = model.StorehouseComponents[component.Key].Item2;
                }
                else
                {
                    house.StorehouseComponents.Add(component.Key, model.StorehouseComponents[component.Key].Item2);
                }
            }
            return house;
        }
        private StorehouseViewModel CreateModel(Storehouse house)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> houseComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in house.StorehouseComponents)
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
                houseComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new StorehouseViewModel
            {
                Id = house.Id,
                StorehouseName = house.StorehouseName,
                Responsible = house.Responsible,
                DateCreate = house.DateCreate,
                StorehouseComponents = houseComponents
            };
        }
      
        public bool Extract(int DishId, int DishCount)
        {
            throw new NotImplementedException();
        }
    }
}
