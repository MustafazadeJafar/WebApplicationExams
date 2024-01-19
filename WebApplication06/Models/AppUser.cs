using Microsoft.AspNetCore.Identity;

namespace WebApplication06.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public string ImagePath { get; set; } = "img/team-1.jpg";
    public bool IsInstructor { get; set; } = false;

    // //
    public IEnumerable<MediaLink>? MediaLinks { get; set; }
    public IEnumerable<InstructorUserRole>? InstructorUserRoles { get; set; }
}
