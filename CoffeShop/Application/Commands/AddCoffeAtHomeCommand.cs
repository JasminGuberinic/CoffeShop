using System;
using System.Collections.Generic;
using System.Text;
using Domain;
using Domain.Entitys;
using Domain.Value;

namespace Application.Command
{
    public class AddCoffeAtHomeCommand
    {
        public Guid Id { get; set; }
        public CoffeAtHome CoffeToGo { get; set; }
    }
}
