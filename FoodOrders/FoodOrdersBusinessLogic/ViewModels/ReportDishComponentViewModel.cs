using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    public class ReportDishComponentViewModel
    {
        public string ComponentName { get; set; }
        public string DishName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Dishs { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
