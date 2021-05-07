using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.HelperModels
{
    public class WordInfoStorehouse
    {

        public string FileName { get; set; }

        public string Title { get; set; }

        public List<StorehouseViewModel> Storehouses { get; set; }
    }
}
