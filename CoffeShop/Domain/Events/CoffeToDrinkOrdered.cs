using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeToDrinkOrdered : DomainEvent
    {
        public CoffeToDrinkOrder CoffeToDrinkOrder;

        public CoffeToDrinkOrdered(CoffeToDrinkOrder CoffeToDrinkOrder)
        {
            this.CoffeToDrinkOrder = CoffeToDrinkOrder;
        }
    }
}
