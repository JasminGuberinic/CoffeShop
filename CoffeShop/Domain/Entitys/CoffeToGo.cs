using Domain.Entitys;
using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CoffeToGo : Entity<CoffeToGoId>
    {
        CoffeToGoId Id { get; set; }
        CoffeToGoPackaging packagin { get; set; }
        Coffe coffe { get; set; }
        Price price { get; set; }
    }

    public class CoffeToGoId : Value<CoffeToGoId>
    {
        public CoffeToGoId(Guid value) => Value = value;

        public Guid Value { get; }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
