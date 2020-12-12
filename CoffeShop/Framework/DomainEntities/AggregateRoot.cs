using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    public abstract class AggregateRoot<TId>
    {
        public TId Id { get; protected set; }
        public int Version { get; private set; } = -1;

        protected abstract void When(object @event);

        private readonly List<DomainEvent> _changes;

        protected AggregateRoot() => _changes = new List<DomainEvent>();

        protected void Apply(DomainEvent @event)
        {
            When(@event);
            EnsureValidState();
            _changes.Add(@event);
        }

        public void Load(int version, IEnumerable<object> history)
        {
            Version = version;

            foreach(var e in history)
            {
                When(e);
            }
        }

        public IEnumerable<DomainEvent> GetChanges() => _changes.AsEnumerable();

        public void ClearChanges() => _changes.Clear();

        protected abstract void EnsureValidState();
    }
}
