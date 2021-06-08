using FoodOrdersBusinessLogic.Attributes;
using FoodOrdersBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public int Id { get; set; }

        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int DishId { get; set; }
       
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        public string ClientFIO { get; set; }
        [Column(title: "Исполнитель", width: 150)]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.AllCells)]
        public string DishName { get; set; }

        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }

        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }

        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }

        [DataMember]
        [Column(title: "Дата создания", width: 100, dateFormat: "d")]
        public DateTime DateCreate { get; set; }

        [Column(title: "Дата выполнения", width: 100, dateFormat: "d")]
        public DateTime? DateImplement { get; set; }
    }
}
