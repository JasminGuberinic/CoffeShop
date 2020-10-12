using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Entitys;
using Domain.Value;

namespace Application.Command
{
    public class AddCoffeCupcakeOrderCommand
    {
        public Guid OrderId { get; set; }
        public Guid Id { get; set; }
        public CoffeCupcakeOrder CoffeToGo { get; set; }
    }
}
