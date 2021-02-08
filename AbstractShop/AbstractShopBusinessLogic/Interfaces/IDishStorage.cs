using AbstractShopBusinessLogic.BindingModels;
using AbstractShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractShopBusinessLogic.Interfaces
{
   public interface IDishStorage
    {
        List<DishViewModel> GetFullList();
        List<DishViewModel> GetFilteredList(DishBindingModel model);
        DishViewModel GetElement(DishBindingModel model);
        void Insert(DishBindingModel model);
        void Update(DishBindingModel model);
        void Delete(DishBindingModel model);
    }
}
