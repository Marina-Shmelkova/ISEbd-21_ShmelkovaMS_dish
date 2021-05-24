using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly int stringsOnPage = 6;
        public List<MessageInfoViewModel> GetFullList()
        {
            using (var context = new FoodOrdersDatabase())
            {
                return context.MessageInfoes
                .Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
                .ToList();
            }
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                var messageInfoes = context.MessageInfoes
                       .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                       (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date) ||
                       (!model.ClientId.HasValue && model.PageNumber.HasValue) ||
                       (model.ClientId.HasValue && rec.ClientId == model.ClientId && model.PageNumber.HasValue));

                if (model.PageNumber.HasValue)
                {
                    if(model.PageNumber.Value == 0)
                    {
                        model.PageNumber = 1;
                    }
                    messageInfoes = messageInfoes.Skip(stringsOnPage * (model.PageNumber.Value - 1))
                        .Take(stringsOnPage);
                }
                return messageInfoes.Select(rec => new MessageInfoViewModel
                {
                    MessageId = rec.MessageId,
                    SenderName = rec.SenderName,
                    DateDelivery = rec.DateDelivery,
                    Subject = rec.Subject,
                    Body = rec.Body
                })
                .ToList();
            }
        }
        public void Insert(MessageInfoBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                MessageInfo element = context.MessageInfoes.FirstOrDefault(rec =>
                rec.MessageId == model.MessageId);
                if (element != null)
                {
                    throw new Exception("Уже есть письмо с таким идентификатором");
                }
                context.MessageInfoes.Add(new MessageInfo
                {
                    MessageId = model.MessageId,
                    ClientId = model.ClientId,
                    SenderName = model.FromMailAddress,
                    DateDelivery = model.DateDelivery,
                    Subject = model.Subject,
                    Body = model.Body
                });
                context.SaveChanges();
            }
        }
    }
}
