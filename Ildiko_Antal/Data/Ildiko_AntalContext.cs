using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ildiko_Antal.Models;

namespace Ildiko_Antal.Models
{
    public class Ildiko_AntalContext : DbContext
    {
        public Ildiko_AntalContext (DbContextOptions<Ildiko_AntalContext> options)
            : base(options)
        {
        }

        public DbSet<Ildiko_Antal.Models.Animale> Animale { get; set; }

        public DbSet<Ildiko_Antal.Models.Adapost> Adapost { get; set; }

        public DbSet<Ildiko_Antal.Models.Specie> Specie { get; set; }
    }
}
