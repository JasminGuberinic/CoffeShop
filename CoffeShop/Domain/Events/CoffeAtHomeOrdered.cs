using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeCupcakeOrderOrdered : DomainEvent
    {
        public CoffeCupcakeOrder CoffeCupcakeOrder { get; set; }

        public CoffeCupcakeOrderOrdered(CoffeCupcakeOrder CoffeCupcakeOrder)
        {
            CoffeCupcakeOrder = CoffeCupcakeOrder;
        }
    }
}
