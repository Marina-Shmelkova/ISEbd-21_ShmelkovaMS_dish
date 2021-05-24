using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.BindingModels
{
    public class StorehouseBindingModel
    {
        public int? Id { get; set; }
        public string StorehouseName { get; set; }
        public string Responsible { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
