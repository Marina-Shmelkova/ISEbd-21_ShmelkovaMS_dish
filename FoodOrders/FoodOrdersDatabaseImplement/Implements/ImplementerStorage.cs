﻿using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        public List<ImplementerViewModel> GetFullList()
        {
            using (var context = new FoodOrdersDatabase())
            {
                return context.Implementers.Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    ImplementerFIO = rec.ImplementerFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                return context.Implementers.Include(x => x.Order)
                 .Where(rec => rec.ImplementerFIO == model.ImplementerFIO)
                 .Select(rec => new ImplementerViewModel
                 {
                     Id = rec.Id,
                     ImplementerFIO = rec.ImplementerFIO,
                     WorkingTime = rec.WorkingTime,
                     PauseTime = rec.PauseTime
                 })
                .ToList();
            }
        }
        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new FoodOrdersDatabase())
            {
                var implementer = context.Implementers.Include(x => x.Order)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return implementer != null ?
                new ImplementerViewModel
                {
                    Id = implementer.Id,
                    ImplementerFIO = implementer.ImplementerFIO,
                    WorkingTime = implementer.WorkingTime,
                    PauseTime = implementer.PauseTime
                } :
                null;
            }
        }
        public void Insert(ImplementerBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                context.Implementers.Add(CreateModel(model, new Implementer()));
                context.SaveChanges();
            }
        }
        public void Update(ImplementerBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                var element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Исполнитель не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new FoodOrdersDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Исполнитель не найден");
                }
            }
        }
        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }
    }
}
