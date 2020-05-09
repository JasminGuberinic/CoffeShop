using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Command
{
    public class AddCoffeToDrinkCommand
    {
        public Guid OrderId { get; set; }
        public Guid Id { get; set; }
        public CoffeToDrink CoffeToDrink { get; set; }
    }
}
