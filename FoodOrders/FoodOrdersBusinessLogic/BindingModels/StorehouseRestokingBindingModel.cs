using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.BindingModels
{
    public class StorehouseRestokingBindingModel
    {
        public int StorehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
