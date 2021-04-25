using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    public class ReportComponentStorehouseViewModel
    {
        public string StorehouseName { get; set; }

        public int TotalCount { get; set; }

        public List<Tuple<string, int>> Components { get; set; } // ComponentName, Count
    }
}
