using FoodOrdersDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersDatabaseImplement
{
    public class FoodOrdersDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3ETGF4T\MSSQLSERVER2;Initial Catalog=FoodOrdersDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Dish> Dishs { set; get; }
        public virtual DbSet<DishComponent> DishComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }

    }
}
