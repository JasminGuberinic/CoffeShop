﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public class CoffeAtHomeOrderDoneCommand
    {
        public Guid OrderId { get; set; }
        public Guid Id { get; set; }
    }
}
