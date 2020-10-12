using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeCupcakeOrderDone : DomainEvent
    {
        public Guid CoffeId { get; set; }
        public CoffeCupcakeOrderDone(Guid id)
        {
            CoffeId = id;
        }
    }
}
