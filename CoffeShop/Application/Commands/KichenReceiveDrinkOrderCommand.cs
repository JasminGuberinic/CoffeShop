﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public class KichenReceivedDrinkOrderCommand
    {
        public Guid OrderId { get; set; }
        public Guid Id { get; set; }
    }
}
