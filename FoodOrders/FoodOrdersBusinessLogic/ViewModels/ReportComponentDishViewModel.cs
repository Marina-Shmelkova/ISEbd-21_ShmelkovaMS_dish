using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    public class ReportComponentDishViewModel
    {
        public string DishName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; }
    }
}
