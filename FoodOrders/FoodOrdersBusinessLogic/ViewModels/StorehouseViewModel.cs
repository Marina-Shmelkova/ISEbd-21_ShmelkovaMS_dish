using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    public class StorehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StorehouseName { get; set; }
        [DisplayName("Ответственный")]
        public string Responsible { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
