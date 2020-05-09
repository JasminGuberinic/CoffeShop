using Domain.Entitys;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class OrderCreated : DomainEvent
    {
        public Guid OrderId { get; set; }

        public bool IsOpen { get; set; }
    }
}
