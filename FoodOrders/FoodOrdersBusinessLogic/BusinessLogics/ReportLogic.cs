using FoodOrdersBusinessLogic.BindingModels;
using FoodOrdersBusinessLogic.HelperModels;
using FoodOrdersBusinessLogic.Interfaces;
using FoodOrdersBusinessLogic.ViewModels;
using FoodOrdersBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IDishStorage _dishStorage;
        private readonly IOrderStorage _orderStorage;
        private readonly IStorehouseStorage _houseStorage;
        public ReportLogic(IDishStorage dishStorage, IOrderStorage orderStorage, IStorehouseStorage houseStorage)
        {
            _dishStorage = dishStorage;
            _orderStorage = orderStorage;
            _houseStorage = houseStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>

        public List<ReportComponentDishViewModel> GetComponentsDish()
        {
            var dishs = _dishStorage.GetFullList();
            var list = new List<ReportComponentDishViewModel>();
            foreach (var dish in dishs)
            {
                var record = new ReportComponentDishViewModel
                {
                    DishName = dish.DishName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var component in dish.DishComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких складах они хранятся
        /// </summary>
        /// <returns></returns>
        public List<ReportComponentStorehouseViewModel> GetComponentStorehouse()
        {
            var houses = _houseStorage.GetFullList();
            var list = new List<ReportComponentStorehouseViewModel>();
            foreach (var house in houses)
            {
                var record = new ReportComponentStorehouseViewModel
                {
                    StorehouseName = house.StorehouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in house.StorehouseComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                DishName = x.DishName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString())).ToString()
            })
           .ToList();
        }
        /// Получение списка заказов сгруппированных по дате
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportAllOrdersViewModel> GetOrdersForAllDates()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportAllOrdersViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>

        public void SaveDishsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Dishs = _dishStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>

        public void SaveComponentDishToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                ComponentDishs = GetComponentsDish()
            });
        }
        public void SaveComponentStorehouseToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                ComponentStorehouses = GetComponentStorehouse()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
        public void SaveStorehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDocStorehouse(new WordInfoStorehouse
            {
                FileName = model.FileName,
                Title = "Таблица складов",
                Storehouses = _houseStorage.GetFullList()
            });
        }
        public void SaveAllOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDocAllOrders(new PdfInfoOrdersAllDates
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrdersForAllDates()
            });
        }
    }
}
