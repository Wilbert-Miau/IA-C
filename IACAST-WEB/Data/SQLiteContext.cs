using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IACAST_WEB.Data
{
    public class SQLiteContext: IdentityDbContext
    {



        public SQLiteContext(DbContextOptions<SQLiteContext> options)
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
