﻿using Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class KichenReceivedDrinkOrder : DomainEvent
    {
        public Guid CoffeId { get; set; }
        public KichenReceivedDrinkOrder(Guid id)
        {
            CoffeId = id;
        }
    }
}
