using Dapper;
using Newtonsoft.Json;
using Paket;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class EventStore
    {
        public async Task SaveEvent(DomainEvent @event, int version, string aggregateId, string aggregateName)
        {
            using (var connection = new SqlConnection(Connections.GetSqlDbConnection()))
            {
                var affectedRows = await connection.ExecuteAsync(SQLQueries.InsertNewEventQuery, new { Id = @event.Id.ToString(),
                    CreatedAt = @event.CreatedAt.ToString(),
                    Version = version, EventName = @event.GetType().Name,
                    AggregateId = aggregateId,
                    MetaData = JsonConvert.SerializeObject(@event),
                    AggregateName = aggregateName
                });
            }
        }

        public async Task SaveEvents(IEnumerable<DomainEvent> uncommittedEvents, int version, string aggregateId, string aggregateName)
        {
            foreach (var sourcedEvent in uncommittedEvents)
            {
                await SaveEvent(sourcedEvent, version, aggregateId, aggregateName);
            }
        }

        public IEnumerable<CommitedEvent> LoadEvents(string aggregateId)
        {
            IEnumerable<CommitedEvent> domainEvents = null;
            string eventsSelectioin = $@"Select CreatedAt, Version, EventName, AggregateId, MetaData, AggregateName 
                                        From EventStore Where AggregateId = {aggregateId}; Order by asc";
            using (var connection = new SqlConnection(Connections.GetSqlDbConnection()))
            {
                domainEvents = connection.Query<CommitedEvent>(eventsSelectioin).ToList();
            }
            return null;
        }

        internal static class SQLQueries
        {
            public const String InsertNewEventQuery = @"INSERT INTO EventStore (CreatedAt, Version, EventName, AggregateId, MetaData, AggregateName) 
                           Values (@Id, @CreatedAt, @Version, @EventName, @AggregateId, @MetaData, @AggregateName);";
        }
    }
}
