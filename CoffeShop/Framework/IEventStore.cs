using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public interface IEventStore
    {
        void CreateNewStream(string streamName, IEnumerable<object> domainEvents);
        void AppendEventsToStream(string streamName, IEnumerable<object> domainEvents, int? expectedVersion);
        IEnumerable<object> GetStream(string streamName, int fromVersion, int toVersion);
        void AddSnapshot<T>(string streamName, T snapshot);
        T GetLatestSnapshot<T>(string streamName) where T : class;
    }
}
