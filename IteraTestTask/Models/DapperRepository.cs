using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IteraTestTask.Models
{
    public class DapperRepository: IEntityRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<FoodOrder> List()
        {
            List<FoodOrder> foodOrders = new List<FoodOrder>();

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                foodOrders = dbConnection.Query<FoodOrder>("SELECT * FROM foodorders").ToList();
            }

            return foodOrders;
        }

        public FoodOrder Get(int? id)
        {
            FoodOrder foodOrder = null;

            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                foodOrder = dbConnection.Query<FoodOrder>("SELECT * FROM FoodOrders f WHERE f.Id = @id", new { id }).FirstOrDefault();
            }

            return foodOrder;
        }

        public void Create(FoodOrder foodOrder)
        {
            using (IDbConnection dbConnection = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO FoodOrders (DishName, Count) VALUES(@DishName, @Count); SELECT CAST(SCOPE_IDENTITY() as int)";
                int orderId = dbConnection.Query<int>(sqlQuery, foodOrder).FirstOrDefault();
                foodOrder.Id = orderId;
            }
        }

        public void Update(FoodOrder foodOrder)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE FoodOrders SET DishName = @DishName, Count = @Count WHERE Id = @Id";
                db.Execute(sqlQuery, foodOrder);
            }
        }

        public void Delete(FoodOrder foodOrder)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM FoodOrders WHERE Id = @Id";
                db.Execute(sqlQuery, foodOrder);
            }
        }
    }
}