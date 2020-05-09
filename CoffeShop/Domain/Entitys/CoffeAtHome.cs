using Domain.Entitys;
using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CoffeAtHome : Entity<CoffeAtHomeId>
    {
        CoffeAtHomeId Id { get; set; }
        CoffeAtHomePackaging packagin { get; set; }
        Coffe coffe { get; set; }
        Price price { get; set; }
        public AcquiringStateAtHomeCoffe AcquiringStateAtHomeCoffe { get; set;}
    }

    public class CoffeAtHomeId : Value<CoffeAtHomeId>
    {
        public CoffeAtHomeId(Guid value) => Value = value;

        public Guid Value { get; }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
