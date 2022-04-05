using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWatcher
{
    public class DbHelper
    {
        private AppDbContext dbContext;

        private DbContextOptions<AppDbContext> GetAllOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseSqlServer(AppSettings.ConnectionString);
            return optionBuilder.Options;
        }

        //GetAllOrders
        public List<OrderFromDB> GetAllOrders()
        {
            using (dbContext = new AppDbContext(GetAllOptions()))
            {
                try
                {
                    var orders = dbContext.Orders.ToList();
                    if (orders != null)
                    {
                        return orders;
                    } else
                    {
                        return new List<OrderFromDB>();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
