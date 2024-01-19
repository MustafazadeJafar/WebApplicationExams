using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication06.Models;

namespace WebApplication06.Conntexts;

public class Edukate01DbContext : IdentityDbContext<AppUser>
{
    public Edukate01DbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<MediaType> MediaTypes { get; set; }
    public DbSet<MediaLink> MediaLinks { get; set; }
}
