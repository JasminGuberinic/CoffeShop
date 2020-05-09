using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class OrderServed : DomainEvent
    {
        public Guid OrderId { get; set; }
    }
}
