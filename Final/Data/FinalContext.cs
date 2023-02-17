using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final.Models;

namespace Final.Data
{
    public class FinalContext : DbContext
    {
        public FinalContext (DbContextOptions<FinalContext> options)
            : base(options)
        {
        }

        public DbSet<Final.Models.Rochie> Rochie { get; set; } = default!;

        public DbSet<Final.Models.Designer> Designer { get; set; }

        public DbSet<Final.Models.Marime> Marime { get; set; }

        public DbSet<Final.Models.Categorie> Categorie { get; set; }

        public DbSet<Final.Models.Accesoriu> Accesoriu { get; set; }

        public DbSet<Final.Models.Clienta> Clienta { get; set; }

        public DbSet<Final.Models.Imprumut> Imprumut { get; set; }
    }
}
