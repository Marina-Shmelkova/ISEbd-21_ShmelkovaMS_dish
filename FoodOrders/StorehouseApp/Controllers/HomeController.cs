using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StorehouseApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace StorehouseApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIEmployer.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouseList"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password != Program.Password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Enter = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(string name, string responsible)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsible))
            {
                APIEmployer.PostRequest("api/storehouse/CreateOrUpdateStorehouse", new StorehouseBindingModel
                {
                    Responsible = responsible,
                    StorehouseName = name,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = new Dictionary<int, (string, int)>()
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите имя и ответственного");
        }

        [HttpGet]
        public IActionResult Update(int storehouseId)
        {
            var storehouse = APIEmployer.GetRequest<StorehouseViewModel>($"api/storehouse/GetStorehouse?storehouseId={storehouseId}");
            ViewBag.Components = storehouse.StorehouseComponents.Values;
            ViewBag.Name = storehouse.StorehouseName;
            ViewBag.Responsible = storehouse.Responsible;
            return View();
        }

        [HttpPost]
        public void Update(int storehouseId, string name, string responsible)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(responsible))
            {
                var storehouse = APIEmployer.GetRequest<StorehouseViewModel>($"api/storehouse/GetStorehouse?storehouseId={storehouseId}");
                if (storehouse == null)
                {
                    return;
                }
                APIEmployer.PostRequest("api/storehouse/CreateOrUpdateStorehouse", new StorehouseBindingModel
                {
                    Responsible = responsible,
                    StorehouseName = name,
                    DateCreate = DateTime.Now,
                    StorehouseComponents = storehouse.StorehouseComponents,
                    Id = storehouse.Id
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Storehouse = APIEmployer.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouseList");
            return View();
        }

        [HttpPost]
        public void Delete(int storehouseId)
        {
            APIEmployer.PostRequest("api/storehouse/DeleteStorehouse", new StorehouseBindingModel
            {
                Id = storehouseId
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Restoking()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Storehouse = APIEmployer.GetRequest<List<StorehouseViewModel>>("api/storehouse/GetStorehouseList");
            ViewBag.Component = APIEmployer.GetRequest<List<ComponentViewModel>>("api/storehouse/GetComponentList");
            return View();
        }

        [HttpPost]
        public void Restoking(int storehouseId, int componentId, int count)
        {
            APIEmployer.PostRequest("api/storehouse/Restocking", new StorehouseRestokingBindingModel
            {
                StorehouseId = storehouseId,
                ComponentId = componentId,
                Count = count
            });
            Response.Redirect("Restoking");
        }
    }
}
