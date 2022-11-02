using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ia.Models;

namespace ia.Data
{
    public class iaContext : DbContext
    {
        public iaContext (DbContextOptions<iaContext> options)
            : base(options)
        {
        }

        public DbSet<ia.Models.Episode> Episode { get; set; } = default!;

        public DbSet<ia.Models.Guest> Guest { get; set; }

        public DbSet<ia.Models.Hosts> Hosts { get; set; }
    }
}
