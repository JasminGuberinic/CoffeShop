using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeAtHomeOrdered : DomainEvent
    {
        public CoffeAtHome CoffeAtHome { get; set; }

        public CoffeAtHomeOrdered(CoffeAtHome coffeAtHome)
        {
            CoffeAtHome = coffeAtHome;
        }
    }
}
