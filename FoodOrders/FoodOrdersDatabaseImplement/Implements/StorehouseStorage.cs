using System;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersBusinessLogic.BindingModels;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FoodOrdersDatabaseImplement.Models;

namespace FoodOrdersDatabaseImplement.Implements
{
   public class StorehouseStorage : IStorehouseStorage
    {
        public List<StorehouseViewModel> GetFullList()
        {
            using (var context = new FoodOrdersDatabase())
            {
                return context.Storehouses
                .Include(rec => rec.StorehouseComponent)
                .ThenInclude(rec => rec.Component)
                .ToList()
                .Select(rec => new StorehouseViewModel
                {
                    Id = rec.Id,
                    StorehouseName = rec.StorehouseName,
                    Responsible = rec.Responsible,
                    DateCreate = rec.DateCreate,
                    StorehouseComponents = rec.StorehouseComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                return context.Storehouses
                .Include(rec => rec.StorehouseComponent)
                .ThenInclude(rec => rec.Component)
                .Where(rec => rec.StorehouseName.Contains(model.StorehouseName))
                .ToList()
                .Select(rec => new StorehouseViewModel
                {
                    Id = rec.Id,
                    StorehouseName = rec.StorehouseName,
                    Responsible = rec.Responsible,
                    DateCreate = rec.DateCreate,
                    StorehouseComponents = rec.StorehouseComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                })
                .ToList();
            }
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                var house = context.Storehouses
                .Include(rec => rec.StorehouseComponent)
                .ThenInclude(rec => rec.Component)
                .FirstOrDefault(rec => rec.StorehouseName.Equals(model.StorehouseName) || rec.Id
                == model.Id);
                return house != null ?
                new StorehouseViewModel
                {
                    Id = house.Id,
                    StorehouseName = house.StorehouseName,
                    Responsible = house.Responsible,
                    DateCreate = house.DateCreate,
                    StorehouseComponents = house.StorehouseComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }
        public void Insert(StorehouseBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Storehouse storehouse = CreateModel(model, new Storehouse());
                        context.Storehouses.Add(storehouse);
                        context.SaveChanges();
                        CreateModel(model, storehouse , context);

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
        public void Update(StorehouseBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
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
        public void Delete(StorehouseBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                Storehouse element = context.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Storehouses.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse house)
        {
            house.StorehouseName = model.StorehouseName;
            house.Responsible = model.Responsible;
            house.DateCreate = model.DateCreate;
            return house;
        }

        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse house,
        FoodOrdersDatabase context)
        {
            house.StorehouseName = model.StorehouseName;
            house.Responsible = model.Responsible;
            house.DateCreate = model.DateCreate;
            if (model.Id.HasValue)
            {
                var dishComponents = context.StorehouseComponents.Where(rec =>
                rec.StorehouseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.StorehouseComponents.RemoveRange(dishComponents.Where(rec =>
                !model.StorehouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in dishComponents)
                {
                    updateComponent.Count =
                    model.StorehouseComponents[updateComponent.ComponentId].Item2;
                    model.StorehouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.StorehouseComponents)
            {
                context.StorehouseComponents.Add(new StorehouseComponent
                {
                    StorehouseId = house.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2,
                });
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            return house;
        }

        public bool Extract(int DishId, int DishCount)
        {
            using (var context = new FoodOrdersDatabase())
            {
                var list = GetFullList();
                var DCount = context.DishComponents.Where(rec => rec.DishId == DishId)
                    .ToDictionary(rec => rec.ComponentId, rec => rec.Count * DishCount);

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var key in DCount.Keys.ToArray())
                        {
                            foreach (var storehouseComponent in context.StorehouseComponents.Where(rec => rec.ComponentId == key))
                            {
                                if (storehouseComponent.Count > DCount[key])
                                {
                                    storehouseComponent.Count -= DCount[key];
                                    DCount[key] = 0;
                                    break;
                                }
                                else
                                {
                                    DCount[key] -= storehouseComponent.Count;
                                    storehouseComponent.Count = 0;
                                }
                            }
                            if (DCount[key] > 0)
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();

                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
