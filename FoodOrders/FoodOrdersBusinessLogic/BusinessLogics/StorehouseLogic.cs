using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class StorehouseLogic
    {
        private readonly IStorehouseStorage _houseStorage;
        private readonly IComponentStorage _componentStorage;
        public StorehouseLogic(IStorehouseStorage houseStorage, IComponentStorage componentStorage)
        {
            _houseStorage = houseStorage;
            _componentStorage = componentStorage;
        }
        public List<StorehouseViewModel> Read(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return _houseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StorehouseViewModel> { _houseStorage.GetElement(model)};
            }
            return _houseStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(StorehouseBindingModel model)
        {
            var element = _houseStorage.GetElement(new StorehouseBindingModel
            {
                StorehouseName = model.StorehouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            if (model.Id.HasValue)
            {
                _houseStorage.Update(model);
            }
            else
            {
                _houseStorage.Insert(model);
            }
        }
        public void Delete(StorehouseBindingModel model)
        {
            var element = _houseStorage.GetElement(new StorehouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Склад не найден");
            }
            _houseStorage.Delete(model);
        }
        public void Restocking(StorehouseRestokingBindingModel model)
        {
            StorehouseViewModel house = _houseStorage.GetElement(new StorehouseBindingModel
            {
                Id = model.StorehouseId
            });

            ComponentViewModel component = _componentStorage.GetElement(new ComponentBindingModel
            {
                Id = model.ComponentId
            });

            if (house == null)
            {
                throw new Exception("Склад не найден");
            }

            if (component == null)
            {
                throw new Exception("Компонент не найден");
            }

            Dictionary<int, (string, int)> houseComponents = house.StorehouseComponents;

            if (houseComponents.ContainsKey(model.ComponentId))
            {
                int count = houseComponents[model.ComponentId].Item2;
                houseComponents[model.ComponentId] = (component.ComponentName, count + model.Count);
            }
            else
            {
                houseComponents.Add(model.ComponentId, (component.ComponentName, model.Count));
            }

            _houseStorage.Update(new StorehouseBindingModel
            {
                Id = house.Id,
                StorehouseName = house.StorehouseName,
                Responsible = house.Responsible,
                DateCreate = house.DateCreate,
                StorehouseComponents = houseComponents
            });
        }
    }
}
