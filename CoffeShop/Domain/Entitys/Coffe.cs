using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entitys
{
    public class Coffe : Entity<CoffeId>
    {
        CoffeId coffeId { get; set; }
        string Name { get; set; }

        Price price { get; set; }
    }

    public class CoffeId : Value<CoffeId>
    {
        public CoffeId(Guid value) => Value = value;

        public Guid Value { get; }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
