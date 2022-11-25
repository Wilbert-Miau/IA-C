using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IACAST_WEB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace IACAST_WEB.Data
{
    public class IACAST_WEBContext : IdentityDbContext
    {
        public IACAST_WEBContext (DbContextOptions<IACAST_WEBContext> options)
            : base(options)
        {
        }

        public DbSet<IACAST_WEB.Models.Episode> Episode { get; set; } = default!;

        public DbSet<IACAST_WEB.Models.Guest> Guest { get; set; }

        public DbSet<IACAST_WEB.Models.Hosts> Hosts { get; set; }

        public DbSet<IACAST_WEB.Models.Post> Post { get; set; }

        public DbSet<IACAST_WEB.Models.Post2> Post2 { get; set; }
    }
}
