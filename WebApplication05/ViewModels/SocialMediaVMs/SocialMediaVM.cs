using WebApplication05.Models;

namespace WebApplication05.ViewModels.SocialMediaVMs;

public class SocialMediaVM
{
    public SocialMediaVM(SocialMedia socialMedia)
    {
        this.Link = socialMedia.Link;
        this.ImagePath = socialMedia.SocialMediaType.ImagePath;
    }

    public string Link { get; set; }
    public string ImagePath { get; set; }
}
