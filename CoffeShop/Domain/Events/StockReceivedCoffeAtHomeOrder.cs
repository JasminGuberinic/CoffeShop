using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class StockReceivedCoffeAtHomeOrder : DomainEvent
    {
        public Guid CoffeId { get; set; }
        public StockReceivedCoffeAtHomeOrder(Guid id)
        {
            CoffeId = id;
        }
    }
}
