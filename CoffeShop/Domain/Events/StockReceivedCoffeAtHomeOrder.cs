using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class StockReceivedCoffeCupcakeOrderOrder : DomainEvent
    {
        public Guid CoffeId { get; set; }
        public StockReceivedCoffeCupcakeOrderOrder(Guid id)
        {
            CoffeId = id;
        }
    }
}
