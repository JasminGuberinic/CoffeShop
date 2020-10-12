using Domain.Entitys;
using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CoffeToDrinkOrder : Entity<CoffeToDrinkOrderId>
    {
        CoffeToDrinkOrderId Id { get; set; }
        bool ToGo { get; set; }
        CoffeToDrinkOrderServing serving { get; set; }
        bool cake { get; set; }
        Coffe coffe { get; set; }
        Price price { get; set; }
        public AcquiringToDrinkCoffe AcquiringToDrinkCoffe { get; set; }
    }

    public class CoffeToDrinkOrderId : Value<CoffeToDrinkOrderId>
    {
        public CoffeToDrinkOrderId(Guid value) => Value = value;

        public Guid Value { get; }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
