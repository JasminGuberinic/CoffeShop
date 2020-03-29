using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderId : Value<OrderId>
    {
        public Guid Value { get; }

        public OrderId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Order id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(OrderId self) => self.Value;

        public static implicit operator OrderId(string value)
            => new OrderId(Guid.Parse(value));

        public override string ToString() => Value.ToString();

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}
