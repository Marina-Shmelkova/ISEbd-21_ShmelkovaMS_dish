using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrdersDatabaseImplement.Models
{
    public class Storehouse
    {
        public int Id { get; set; }
        [Required]
        public string StorehouseName { get; set; }
        [Required]
        public string Responsible { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [ForeignKey("StorehouseId")]
        public List<StorehouseComponent> StorehouseComponent { get; set; }
    }
}
