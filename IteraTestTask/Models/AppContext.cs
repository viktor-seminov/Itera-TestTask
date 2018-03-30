using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IteraTestTask.Models
{
    public class AppContext: DbContext
    {
        public AppContext() : base("DefaultConnection")
        { }

        public DbSet<FoodOrder> FoodOrders { get; set; }
    }
}