﻿using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.Interfaces;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.BusinessLogics
{
	public class DishLogic
	{
		private readonly IDishStorage _dishStorage;
		public DishLogic(IDishStorage dishStorage)
		{
			_dishStorage = dishStorage;
		}
        public List<DishViewModel> Read(DishBindingModel model)
        {
            if (model == null)
            {
                return _dishStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<DishViewModel> { _dishStorage.GetElement(model)
};
            }
            return _dishStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(DishBindingModel model)
        {
            var element = _dishStorage.GetElement(new DishBindingModel
            {
                DishName = model.DishName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть набор блюд с таким названием");
            }
            if (model.Id.HasValue)
            {
                _dishStorage.Update(model);
            }
            else
            {
                _dishStorage.Insert(model);
            }
        }
        public void Delete(DishBindingModel model)
        {
            var element = _dishStorage.GetElement(new DishBindingModel
            {
                Id =
           model.Id
            });
            if (element == null)
            {
                throw new Exception("Набор блюд не найден");
            }
            _dishStorage.Delete(model);
        }
    }
}
