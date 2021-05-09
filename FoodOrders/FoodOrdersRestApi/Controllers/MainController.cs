﻿using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrdersRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly DishLogic _dish;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, DishLogic dish, OrderLogic main)
        {
            _order = order;
            _dish = dish;
            _main = main;
        }
        [HttpGet]
        public List<DishViewModel> GetDishList() => _dish.Read(null)?.ToList();

        [HttpGet]
        public DishViewModel GetDish(int dishId) => _dish.Read(new DishBindingModel { Id = dishId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
