using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IACAST_WEB.Models;

namespace IACAST_WEB.Data
{
    public class IACAST_WEBContext : DbContext
    {
        public IACAST_WEBContext (DbContextOptions<IACAST_WEBContext> options)
            : base(options)
        {
        }

        public DbSet<IACAST_WEB.Models.Episode> Episode { get; set; } = default!;

        public DbSet<IACAST_WEB.Models.Guest> Guest { get; set; }

        public DbSet<IACAST_WEB.Models.Hosts> Hosts { get; set; }
    }
}
