using FoodOrdersBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.HelperModels
{
    public class MailCheckInfo
    {
        public string PopHost { get; set; }

        public int PopPort { get; set; }

        public IMessageInfoStorage MessageStorage { get; set; }

        public IClientStorage ClientStorage { get; set; }
    }
}
