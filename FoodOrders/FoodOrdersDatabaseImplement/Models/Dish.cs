using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FoodOrdersDatabaseImplement.Models
{
    public class Dish
    {
        public int Id { get; set; }

        [ForeignKey("DishId")]
        public virtual List<DishComponent> DishComponent { get; set; }

        [ForeignKey("DishId")]
        public virtual List<Order> Order { get; set; }

        [Required]
        public string DishName { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
