using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public class SnapshotWrapper
    {
        public string StreamName { get; set; }
        public Object Snapshot { get; set; }
        public DateTime Created { get; set; }
    }
}
