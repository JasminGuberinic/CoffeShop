using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public abstract class DomainEvent : IEvent
    {

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
