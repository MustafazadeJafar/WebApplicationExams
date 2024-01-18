using WebApplication05.Models;
using WebApplication05.Modelsl;

namespace WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;

public class SocialMediaEditVM
{
    public SocialMediaEditVM() { }
    public SocialMediaEditVM(SocialMedia socialMedia)
    {
        this.Link = socialMedia.Link;
        this.TypeId = socialMedia.SocialMediaTypeId;
    }

    public string? Link { get; set; }
    public int? TypeId { get; set; }
}
