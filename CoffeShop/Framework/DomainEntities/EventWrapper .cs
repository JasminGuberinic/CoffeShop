using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public class EventWrapper
    {
        public string Id { get; private set; }
        public object Event { get; private set; } // DomainEvent
        public string EventStreamId { get; private set; }
        public int EventNumber { get; private set; }
        public EventWrapper(object @event, int eventNumber, string streamStateId) { Event = @event; EventNumber = eventNumber; EventStreamId = streamStateId; Id = string.Format("{0}-{1}", streamStateId, EventNumber); }
    }
}
