using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class DrinkOrderDone : DomainEvent
    {
        public Guid CoffeId { get; set; }
        public DrinkOrderDone(Guid id)
        {
            CoffeId = id;
        }
    }
}
