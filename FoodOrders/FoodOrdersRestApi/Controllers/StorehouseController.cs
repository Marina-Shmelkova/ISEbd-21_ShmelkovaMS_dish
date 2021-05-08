using System;
using System.Collections.Generic;
using System.Linq;
using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrdersRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorehouseController : Controller
    {
        private readonly StorehouseLogic _storehouse;

        private readonly ComponentLogic _component;

        public StorehouseController(StorehouseLogic houseLogic, ComponentLogic componentLogic)
        {
            _storehouse = houseLogic;
            _component = componentLogic;
        }
        [HttpGet]
        public List<StorehouseViewModel> GetStorehouseList() => _storehouse.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateStorehouse(StorehouseBindingModel model)
            => _storehouse.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorehouse(StorehouseBindingModel model) => _storehouse.Delete(model);

        [HttpPost]
        public void Restocking(StorehouseRestokingBindingModel model)
            => _storehouse.Restocking(model);

        [HttpGet]
        public StorehouseViewModel GetStorehouse(int storehouseId)
            => _storehouse.Read(new StorehouseBindingModel { Id = storehouseId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponentList()
            => _component.Read(null);
    }
}
