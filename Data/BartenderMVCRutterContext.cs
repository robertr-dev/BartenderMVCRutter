using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BartenderMVCRutter.Models;

namespace BartenderMVCRutter.Data
{
    public class BartenderMVCRutterContext : DbContext
    {
        public BartenderMVCRutterContext (DbContextOptions<BartenderMVCRutterContext> options)
            : base(options)
        {
        }

        public DbSet<BartenderMVCRutter.Models.Customer> Customer { get; set; } = default!;

        public DbSet<BartenderMVCRutter.Models.Drink>? Drink { get; set; }

        public DbSet<BartenderMVCRutter.Models.Order>? Order { get; set; }
    }
}
