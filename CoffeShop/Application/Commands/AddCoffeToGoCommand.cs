using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Entitys;
using Domain.Value;

namespace Application.Command
{
    public class AddCoffeToGoCommand
    {
        public Guid Id { get; set; }
        public CoffeToGo CoffeToGo { get; set; }
    }
}
