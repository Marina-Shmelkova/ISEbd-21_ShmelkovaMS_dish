using FoodOrdersBusinessLogic.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace FoodOrdersBusinessLogic.ViewModels
{
    /// <summary>
    /// Сообщения, приходящие на почту
    /// </summary>
    [DataContract]
    public class MessageInfoViewModel
    {
        [DataMember]
        [Column(title: "Номер", width: 100, visible: false)]
        public string MessageId { get; set; }
        [DataMember]
        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; }
        [DataMember]
        [Column(title: "Дата письма", width: 100)]
        public DateTime DateDelivery { get; set; }
        [DataMember]
        [Column(title: "Заголовок", width: 100)]
        public string Subject { get; set; }
        [DataMember]
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.AllCells)]
        public string Body { get; set; }
    }
}
