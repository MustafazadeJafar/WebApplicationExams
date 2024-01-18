using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication05.Models;
using WebApplication05.Modelsl;

namespace WebApplication05.Contexts;

public class Cial01DbContext : IdentityDbContext<AppUser>
{
    public Cial01DbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<SocialMediaType> SocialMediaTypes { get; set; }
}
