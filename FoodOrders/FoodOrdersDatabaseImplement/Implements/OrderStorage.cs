using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        { 
                using (var context = new FoodOrdersDatabase())
                {
                    return context.Orders.Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        DishName = context.Dishs.Include(x => x.Order).FirstOrDefault(r => r.Id == rec.DishId).DishName,
                        DishId = rec.DishId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                        ClientId = rec.ClientId,
                        ClientFIO = context.Clients.FirstOrDefault(x => x.Id == rec.ClientId).ClientFIO
                    })
                    .ToList();
                }
            }

            public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }

                using (var context = new FoodOrdersDatabase())
                {
                    return context.Orders
                    .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) || (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate == model.DateCreate) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date
                    >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date))
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        DishName = context.Dishs.Include(x => x.Order).FirstOrDefault(r => r.Id == rec.DishId).DishName,
                        DishId = rec.DishId,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                        ClientId = rec.ClientId
                    })
                    .ToList();
                }
            }

            public OrderViewModel GetElement(OrderBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new FoodOrdersDatabase())
                {
                    var order = context.Orders
                    .FirstOrDefault(rec => rec.Id == model.Id);
                    return order != null ?
                    new OrderViewModel
                    {
                        Id = order.Id,
                        DishName = context.Dishs.Include(x => x.Order).FirstOrDefault(r => r.Id == order.DishId)?.DishName,
                        DishId = order.DishId,
                        Count = order.Count,
                        Sum = order.Sum,
                        Status = order.Status,
                        DateCreate = order.DateCreate,
                        DateImplement = order.DateImplement,
                        ClientId = order.ClientId
                    } :
                    null;
                }
            }

            public void Insert(OrderBindingModel model)
            {
                using (var context = new FoodOrdersDatabase())
                {
                    context.Orders.Add(CreateModel(model, new Order()));
                    context.SaveChanges();
                }
            }

            public void Update(OrderBindingModel model)
            {
                using (var context = new FoodOrdersDatabase())
                {
                    var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    CreateModel(model, element);
                    context.SaveChanges();
                }
            }

            public void Delete(OrderBindingModel model)
            {
                using (var context = new FoodOrdersDatabase())
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element != null)
                    {
                        context.Orders.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
            }

            private Order CreateModel(OrderBindingModel model, Order order)
            {
                order.DishId = model.DishId;
                order.Count = model.Count;
                order.Sum = model.Sum;
                order.Status = model.Status;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;
                order.ClientId = (int)model.ClientId;
                return order;
            }
        }
}
