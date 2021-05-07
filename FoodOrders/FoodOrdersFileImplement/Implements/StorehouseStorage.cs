using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrdersFileImplement.Implements
{
    public class StorehouseStorage : IStorehouseStorage
    {
        private readonly FileDataListSingleton source;
        public StorehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            return source.Storehouses
            .Select(CreateModel)
            .ToList();
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Storehouses
            .Where(rec => rec.StorehouseName.Contains(model.StorehouseName))
            .Select(CreateModel)
            .ToList();
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var house = source.Storehouses
            .FirstOrDefault(rec => rec.StorehouseName == model.StorehouseName || rec.Id == model.Id);
            return house != null ? CreateModel(house) : null;
        }

        public void Insert(StorehouseBindingModel model)
        {
            int maxId = source.Storehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Storehouse { Id = maxId + 1, StorehouseComponents = new Dictionary<int, int>() };
            source.Storehouses.Add(CreateModel(model, element));
        }
        public void Update(StorehouseBindingModel model)
        {
            var element = source.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(StorehouseBindingModel model)
        {
            Storehouse element = source.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Storehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
            return new StorehouseViewModel
            {
                Id = house.Id,
                StorehouseName = house.StorehouseName,
                Responsible = house.Responsible,
                DateCreate = house.DateCreate,
                StorehouseComponents = house.StorehouseComponents.ToDictionary(recPC => recPC.Key, recPC => (source.Components.FirstOrDefault(recC => recC.Id == recPC.Key)?.ComponentName, recPC.Value))
            };
        }
       /* public void Availability(StorehouseBindingModel houseBindingModel, int StorehouseId, int ComponentId, int Count, string ComponentName)
        {
            StorehouseViewModel view = GetElement(new StorehouseBindingModel
            {
                Id = StorehouseId
            });

            if (view != null)
            {
                houseBindingModel.StorehouseComponents = view.StorehouseComponents;
                houseBindingModel.DateCreate = view.DateCreate;
                houseBindingModel.Id = view.Id;
                houseBindingModel.Responsible = view.Responsible;
                houseBindingModel.StorehouseName = view.StorehouseName;
            }

            if (houseBindingModel.StorehouseComponents.ContainsKey(ComponentId))
            {
                int count = houseBindingModel.StorehouseComponents[ComponentId].Item2;
                houseBindingModel.StorehouseComponents[ComponentId] = (ComponentName, count + Count);
            }
            else
            {
                houseBindingModel.StorehouseComponents.Add(ComponentId, (ComponentName, Count));
            }
            Update(houseBindingModel);
        }*/
        public bool Extract(int DishCount, int DishId)
        {
            var list = GetFullList();

            var DCount = source.Dishs.FirstOrDefault(rec => rec.Id == DishId).DishComponents;

            DCount = DCount.ToDictionary(rec => rec.Key, rec => rec.Value * DishCount);

            Dictionary<int, int> Have = new Dictionary<int, int>();

            foreach (var view in list)
            {
                foreach (var d in view.StorehouseComponents)
                {
                    int key = d.Key;
                    if (DCount.ContainsKey(key))
                    {
                        if (Have.ContainsKey(key))
                        {
                            Have[key] += d.Value.Item2;
                        }
                        else
                        {
                            Have.Add(key, d.Value.Item2);
                        }
                    }
                }
            }

            foreach (var key in Have.Keys)
            {
                if (DCount[key] > Have[key])
                {
                    return false;
                }
            }

            foreach (var view in list)
            {
                var houseComponents = view.StorehouseComponents;
                foreach (var key in view.StorehouseComponents.Keys.ToArray())
                {
                    var value = view.StorehouseComponents[key];
                    if (DCount.ContainsKey(key))
                    {
                        if (value.Item2 > DCount[key])
                        {
                            houseComponents[key] = (value.Item1, value.Item2 - DCount[key]);
                            DCount[key] = 0;
                        }
                        else
                        {
                            houseComponents[key] = (value.Item1, 0);
                            DCount[key] -= value.Item2;
                        }
                        Update(new StorehouseBindingModel
                        {
                            Id = view.Id,
                            StorehouseName = view.StorehouseName,
                            Responsible = view.Responsible,
                            DateCreate = view.DateCreate,
                            StorehouseComponents = houseComponents
                        });
                    }
                }
            }
            return true;
        }
    }
}
