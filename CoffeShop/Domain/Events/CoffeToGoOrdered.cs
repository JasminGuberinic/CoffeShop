using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class CoffeToGoOrdered
    {
        public CoffeToGo CoffeToGo { get; set; }

        public CoffeToGoOrdered(CoffeToGo coffeToGo)
        {
            CoffeToGo = coffeToGo;
        }
    }
}
