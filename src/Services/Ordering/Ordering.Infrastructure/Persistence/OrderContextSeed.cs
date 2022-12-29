using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() 
                {
                    UserName = "erandika", 
                    FirstName = "Erandika", 
                    LastName = "Sandaruwan", 
                    EmailAddress = "erandika1986@gmail.com", 
                    AddressLine = "12/530 Galawaladeniya, Weboda", 
                    Country = "Sri Lanka", 
                    State = "Western",
                    TotalPrice = 350 
                }
            };
        }
    }
}
