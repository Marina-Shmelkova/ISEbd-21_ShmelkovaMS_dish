using System;
using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class DishStorage : IDishStorage
    {
        public List<DishViewModel> GetFullList()
        {
            using (var context = new FoodOrdersDatabase())
            {
                return context.Dishs
                .Include(rec => rec.DishComponent)
               .ThenInclude(rec => rec.Component)
               .ToList()
               .Select(rec => new DishViewModel
               {
                   Id = rec.Id,
                   DishName = rec.DishName,
                   Price = rec.Price,
                   DishComponents = rec.DishComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<DishViewModel> GetFilteredList(DishBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                return context.Dishs
                .Include(rec => rec.DishComponent)
               .ThenInclude(rec => rec.Component)
               .Where(rec => rec.DishName.Contains(model.DishName))
               .ToList()
               .Select(rec => new DishViewModel
               {
                   Id = rec.Id,
                   DishName = rec.DishName,
                   Price = rec.Price,
                   DishComponents = rec.DishComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
               })
                .ToList();
            }
        }
        public DishViewModel GetElement(DishBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                var dish = context.Dishs
                .Include(rec => rec.DishComponent)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.DishName == model.DishName || rec.Id
               == model.Id);
                return dish != null ?
                new DishViewModel
                {
                    Id = dish.Id,
                    DishName = dish.DishName,
                    Price = dish.Price,
                    DishComponents = dish.DishComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(DishBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Dish dish = CreateModel(model, new Dish());
                        context.Dishs.Add(dish);
                        context.SaveChanges();
                        dish = CreateModel(model, dish, context);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(DishBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Dishs.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(DishBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                Dish element = context.Dishs.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Dishs.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Dish CreateModel(DishBindingModel model, Dish dish)
        {
            dish.DishName = model.DishName;
            dish.Price = model.Price;
            return dish;
        }
        private Dish CreateModel(DishBindingModel model, Dish dish, FoodOrdersDatabase context)
        {
            dish.DishName = model.DishName;
            dish.Price = model.Price;
            if (model.Id.HasValue)
            {
                var dishComponents = context.DishComponents.Where(rec =>
               rec.DishId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.DishComponents.RemoveRange(dishComponents.Where(rec =>
                !model.DishComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in dishComponents)
                {
                    updateComponent.Count =
                    model.DishComponents[updateComponent.ComponentId].Item2;
                    model.DishComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.DishComponents)
            {
                context.DishComponents.Add(new DishComponent
                {
                    DishId = dish.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    MessageBox.Show(e?.InnerException?.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            return dish;
        }
    }
}
