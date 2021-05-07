using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersListImplement.Models
{
    public class Storehouse
    {
        public int Id { get; set; }
        public string StorehouseName { get; set; }
        public string Responsible { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, int> StorehouseComponents { get; set; }
    }
}
