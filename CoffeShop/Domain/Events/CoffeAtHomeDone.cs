using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeAtHomeDone : DomainEvent
    {
        public Guid CoffeId { get; set; }
        public CoffeAtHomeDone(Guid id)
        {
            CoffeId = id;
        }
    }
}
