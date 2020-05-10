using infrastructure.DB;
using infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace infrastructure.Repositories
{
    class OrderReadModelRepository
    {
        CoffeShopContext coffeShopContext;
        public OrderReadModelRepository()
        {
            coffeShopContext = new CoffeShopContext();
        }

        public Order GetOrderByID(string Id)
        {
            return coffeShopContext.Orders.FirstOrDefault(oreder => oreder.Id == Id);
        }
    }
}
