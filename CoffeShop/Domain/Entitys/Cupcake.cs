using Domain.Value;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Cupcake : Entity<CupcakeId>
    {
       CupcakeId coffeId { get; set; }

       string Name { get; set; }

       Price price { get; set; }
    }

    public class CupcakeId : Value<CupcakeId>
    {
       public CupcakeId(Guid value) => Value = value;

       public Guid Value { get; }

       protected override int GetHashCodeCore()
       {
            throw new NotImplementedException();
       }
    }
}
