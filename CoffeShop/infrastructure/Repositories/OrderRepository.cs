using Domain;
using Framework;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infrastructure
{
    public class OrderRepository
    {
        EventStore eventStore = new EventStore();
        public Order LoadAsync(string aggregateID)
        {
            var commitedevents = eventStore.LoadEvents(aggregateID);
            var domainevents = commitedevents.Select(Transform);
            return new Order(domainevents);
        }

        public async Task SaveAsync(Order order)
        {
            await SaveAggregateAsync(order.GetType().Name, order.Id.Value.ToString(), order.Version, order.GetChanges());
        }

        private async Task SaveAggregateAsync(string aggregateName, string aggregateID, int version, IEnumerable<DomainEvent> domainEvents)
        {
            await eventStore.SaveEvents(domainEvents, version, aggregateID, aggregateName);
        }

        private DomainEvent Transform(CommitedEvent commitedEvent)
        {
            var e = JsonConvert.DeserializeObject<DomainEvent>(commitedEvent.MetaData);
            return e;
        }
    }
}
