using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.HelperModels
{
    public class PdfInfoOrdersAllDates
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportAllOrdersViewModel> Orders { get; set; }
    }
}