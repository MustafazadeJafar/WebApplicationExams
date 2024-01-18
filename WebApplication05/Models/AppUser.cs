using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication05.Models;

public class AppUser : IdentityUser
{
    [MaxLength(63)]
    public string Fullname { get; set; }
    public string? ImagePath { get; set; }
    public bool IsWorker { get; set; } = false;

    // //
    public IEnumerable<SocialMedia>? SocialMedias { get; set; }
}
