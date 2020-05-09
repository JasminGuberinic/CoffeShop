using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeToDrinkOrdered : DomainEvent
    {
        public CoffeToDrink coffeToDrink;

        public CoffeToDrinkOrdered(CoffeToDrink coffeToDrink)
        {
            this.coffeToDrink = coffeToDrink;
        }
    }
}
