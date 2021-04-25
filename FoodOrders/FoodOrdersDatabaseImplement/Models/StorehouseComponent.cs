using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodOrdersDatabaseImplement.Models
{
    public class StorehouseComponent
    {
        public int Id { get; set; }
        public int StorehouseId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Storehouse Storehouse { get; set; }
    }
}
