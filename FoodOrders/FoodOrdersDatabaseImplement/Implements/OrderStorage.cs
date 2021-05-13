﻿using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Enums;
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
                return context.Orders.Include(rec => rec.Dish).Include(rec => rec.Client)
                    .Include(rec => rec.Implementer).Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ClientId = rec.ClientId,
                        ClientFIO = rec.Client.ClientFIO,
                        ImplementerId = rec.ImplementerId,
                        ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                        DishId = rec.DishId,
                        DishName = rec.Dish.DishName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
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
                     .Include(rec => rec.Dish)
                     .Include(rec => rec.Client)
                     .Include(rec => rec.Implementer)
                     .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
                    rec.DateCreate.Date == model.DateCreate.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue &&
                    rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <=
                    model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                    (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status == OrderStatus.Принят) ||
                    (model.ImplementerId.HasValue && rec.ImplementerId ==
                    model.ImplementerId && rec.Status == OrderStatus.Выполняется) ||
                    (model.NeedComponentOrders.HasValue && model.NeedComponentOrders.Value && rec.Status ==
                    OrderStatus.Требуются_материалы))
                     .Select(rec => new OrderViewModel
                 {
                        Id = rec.Id,
                        ClientId = rec.ClientId,
                        ClientFIO = rec.Client.ClientFIO,
                        ImplementerId = rec.ImplementerId,
                        ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                        DishId = rec.DishId,
                        DishName = rec.Dish.DishName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement
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
                    var order = context.Orders.Include(rec => rec.Dish).Include(rec => rec.Client)
                        .Include(rec => rec.Implementer).FirstOrDefault(rec => rec.Id == model.Id);
                    return order != null ?
                    new OrderViewModel
                    {
                        Id = order.Id,
                        ClientId = order.ClientId,
                        ClientFIO = order.Client.ClientFIO,
                        ImplementerId = order.ImplementerId,
                        ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
                        DishId = order.DishId,
                        DishName = order.Dish.DishName,
                        Count = order.Count,
                        Sum = order.Sum,
                        Status = order.Status,
                        DateCreate = order.DateCreate,
                        DateImplement = order.DateImplement
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
                order.ClientId = model.ClientId.Value;
                order.ImplementerId = model.ImplementerId;
                return order;
            }
        }
}
