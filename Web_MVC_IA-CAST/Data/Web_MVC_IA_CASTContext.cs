using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web_MVC_IA_CAST.Models;

namespace Web_MVC_IA_CAST.Data
{
    public class Web_MVC_IA_CASTContext : DbContext
    {
        public Web_MVC_IA_CASTContext (DbContextOptions<Web_MVC_IA_CASTContext> options)
            : base(options)
        {
        }

        public DbSet<Web_MVC_IA_CAST.Models.podcastEpisodeModel> podcastEpisodeModel { get; set; } = default!;

        public DbSet<Web_MVC_IA_CAST.Models.hostModel> hostModel { get; set; }

        public DbSet<Web_MVC_IA_CAST.Models.guestModel> guestModel { get; set; }
    }
}
