using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class MoqRepo
    {
        Order order = new Order(Guid.NewGuid(), true);

        public Order getOrder(Guid id)
        {
            return order;
        }
    }
}
