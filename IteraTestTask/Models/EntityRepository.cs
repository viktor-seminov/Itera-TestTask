using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace IteraTestTask.Models
{
    public class EntityRepository : IDisposable, IEntityRepository
    {
        private AppContext foodContext;

        public EntityRepository()
        {
            foodContext = new AppContext();
        }
        
        public IEnumerable<FoodOrder> List()
        {
            return foodContext.FoodOrders;
        }

        public FoodOrder Get(int? id)
        {
            return foodContext.FoodOrders.Find(id);
        }

        public void Create(FoodOrder foodOrder)
        {
            foodContext.Entry(foodOrder).State = EntityState.Added;
            foodContext.SaveChanges();
        }

        public void Update(FoodOrder foodOrder)
        {
            foodContext.Entry(foodOrder).State = EntityState.Modified;
            foodContext.SaveChanges();
        }

        public void Delete(FoodOrder foodOrder)
        {
            foodContext.Entry(foodOrder).State = EntityState.Deleted;
            foodContext.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (foodContext != null)
                {
                    foodContext.Dispose();
                    foodContext = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}