using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public class CreateOrderCommand
    {
        public Guid Id { get; set; }
        public bool IsOpen { get; set; }
    }
}
