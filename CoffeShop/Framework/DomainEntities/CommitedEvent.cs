using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public class CommitedEvent
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Version { get; set; }
        public string EventName { get; set; }
        public string AggregateId { get; set; }
        public string MetaData { get; set; }
        public string AggregateName { get; set; }
    }
}
