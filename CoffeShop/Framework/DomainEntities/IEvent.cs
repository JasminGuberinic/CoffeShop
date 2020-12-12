using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public interface IEvent
    {
        Guid Id { get; set; }
    }
}
