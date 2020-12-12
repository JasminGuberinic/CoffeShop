using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }
    }
}
