using WebApplication05.Models;

namespace WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;

public class SocialMediaCreateVM
{
    //public int AppUserId { get; set; }
    public int SocialMediaTypeId { get; set; }

    public string Link { get; set; }

    public SocialMedia ToMediaLink()
    {
        return new()
        {
            SocialMediaTypeId = this.SocialMediaTypeId,
            Link = this.Link,
        };
    }
}
