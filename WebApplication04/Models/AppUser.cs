using Microsoft.AspNetCore.Identity;

namespace WebApplication04.Models;

public class AppUser : IdentityUser
{
    public string ImagePath { get; set; }

    // //
    //public IEnumerable<Blog> Blogs { get; set; }
}
