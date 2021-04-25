using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    public class ReportAllOrdersViewModel
    {
        public DateTime Date { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
