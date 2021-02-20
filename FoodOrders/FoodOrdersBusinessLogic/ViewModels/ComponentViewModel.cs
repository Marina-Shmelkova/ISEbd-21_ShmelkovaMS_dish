using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    /// <summary>
    /// Компонент, требуемый для изготовления изделия
    /// </summary>
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название блюда")]
        public string ComponentName { get; set; }
    }
}
