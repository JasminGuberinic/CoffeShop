using Domain;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.DB
{
    public class CoffeShopContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Coffe> Coffes { get; set; }
    }
}
