using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.Interfaces
{
    public interface IStorehouseStorage
    {
        List<StorehouseViewModel> GetFullList();
        List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model);
        StorehouseViewModel GetElement(StorehouseBindingModel model);
        void Insert(StorehouseBindingModel model);
        void Update(StorehouseBindingModel model);
        void Delete(StorehouseBindingModel model);
    }
}
