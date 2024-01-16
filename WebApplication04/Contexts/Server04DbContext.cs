using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication04.Models;

namespace WebApplication04.Contexts;

public class Server04DbContext : IdentityDbContext<AppUser>
{
    public Server04DbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Blog> Blogs { get; set; }
}
