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
        private readonly StorehouseLogic _house;

        private readonly ComponentLogic _component;

        public StorehouseController(StorehouseLogic houseLogic, ComponentLogic componentLogic)
        {
            _house = houseLogic;
            _component = componentLogic;
        }
        [HttpGet]
        public List<StorehouseViewModel> GetStorehouseList() => _house.Read(null)?.ToList();

        [HttpPost]
        public void CreateOrUpdateStorehouse(StorehouseBindingModel model)
            => _house.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorehouse(StorehouseBindingModel model) => _house.Delete(model);

        [HttpPost]
        public void Restoking(StorehouseRestokingBindingModel model)
            => _house.Restocking(model);

        [HttpGet]
        public StorehouseViewModel GetStorehouse(int houseId)
            => _house.Read(new StorehouseBindingModel { Id = houseId })?[0];

        [HttpGet]
        public List<ComponentViewModel> GetComponentList()
            => _component.Read(null);
    }
}
