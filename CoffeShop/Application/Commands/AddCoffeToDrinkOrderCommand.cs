using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public class AddCoffeToDrinkOrderCommand
    {
        public Guid OrderId { get; set; }
        public Guid Id { get; set; }
        public CoffeToDrinkOrder CoffeToDrinkOrder { get; set; }
    }
}
