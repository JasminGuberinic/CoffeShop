using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public interface ISubscriber
    {
        Task Project(object @event);
    }
}
