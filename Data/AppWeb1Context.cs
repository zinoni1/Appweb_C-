using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppWeb1.Models;

namespace AppWeb1.Data
{
    public class AppWeb1Context : DbContext
    {
        public AppWeb1Context (DbContextOptions<AppWeb1Context> options)
            : base(options)
        {
        }

        public DbSet<AppWeb1.Models.Serie> Serie { get; set; } = default!;

        public DbSet<AppWeb1.Models.Plataforma>? Plataforma { get; set; }

        public DbSet<AppWeb1.Models.Client>? Client { get; set; }
    }
}
