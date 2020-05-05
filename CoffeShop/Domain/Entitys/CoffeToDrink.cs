using Domain.Entitys;
using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CoffeToDrink : Entity<CoffeToDrinkId>
    {
        CoffeToDrinkId Id { get; set; }
        bool ToGo { get; set; }
        CoffeToDrinkServing serving { get; set; }
        bool cake { get; set; }
        Coffe coffe { get; set; }
        Price price { get; set; }
    }

    public class CoffeToDrinkId : Value<CoffeToDrinkId>
    {
        public CoffeToDrinkId(Guid value) => Value = value;

        public Guid Value { get; }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
