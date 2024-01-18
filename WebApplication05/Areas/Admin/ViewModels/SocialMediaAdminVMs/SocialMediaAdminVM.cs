using WebApplication05.Models;

namespace WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;

public class SocialMediaAdminVM
{
    public SocialMediaAdminVM(SocialMedia socialMedia)
    {
        this.Id = socialMedia.Id;
        this.UserName = socialMedia.AppUser.UserName;
        this.Link = socialMedia.Link;
        this.TypeName = socialMedia.SocialMediaType.TypeName;
        this.IsActive = socialMedia.IsActive;
    }

    public int Id { get; set; }
    public string UserName { get; set; }
    public string TypeName { get; set; }
    public string Link { get; set; }
    public bool IsActive { get; set; }
}
