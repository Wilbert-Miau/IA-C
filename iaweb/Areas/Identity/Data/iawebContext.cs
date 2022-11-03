using iaweb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using iaweb.Models;

namespace iaweb.Data;

public class iawebContext : IdentityDbContext<iawebUser>
{
    public iawebContext(DbContextOptions<iawebContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<iaweb.Models.Episode> Episode { get; set; }

    public DbSet<iaweb.Models.Guest> Guest { get; set; }

    public DbSet<iaweb.Models.Hosts> Hosts { get; set; }
}
