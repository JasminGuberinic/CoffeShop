using Domain.Entitys;
using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CoffeCupcakeOrder : Entity<CoffeCupcakeOrderId>
    {
        CoffeCupcakeOrderId Id { get; set; }
        CoffeCupcakeOrderPackaging packagin { get; set; }
        Coffe coffe { get; set; }
        Price price { get; set; }
        public AcquiringStateCoffeCupcake AcquiringStateAtHomeCoffe { get; set;}
    }

    public class CoffeCupcakeOrderId : Value<CoffeCupcakeOrderId>
    {
        public CoffeCupcakeOrderId(Guid value) => Value = value;

        public Guid Value { get; }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
