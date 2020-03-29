using Domain.Entitys;
using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class OrderCreated : IEvent
    {
        public string Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Guid OrderId { get; set; }

        public bool IsOpen { get; set; }
    }
}
