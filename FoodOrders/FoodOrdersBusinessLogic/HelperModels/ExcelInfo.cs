using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportComponentDishViewModel> ComponentDishs { get; set; }
    }
}
