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
        public StorehouseLogic(IStorehouseStorage houseStorage)
        {
            _houseStorage = houseStorage;
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
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Склад не найден");
            }
            _houseStorage.Delete(model);
        }
    }
}
