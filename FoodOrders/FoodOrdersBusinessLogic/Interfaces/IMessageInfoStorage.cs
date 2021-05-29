using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
        int Count();
        List<MessageInfoViewModel> GetMessagesForPage(MessageInfoBindingModel model);
    }
}
