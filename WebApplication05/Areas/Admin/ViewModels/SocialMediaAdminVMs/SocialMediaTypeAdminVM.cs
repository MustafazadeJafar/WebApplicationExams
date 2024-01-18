using WebApplication05.Modelsl;

namespace WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;

public class SocialMediaTypeAdminVM
{
    public SocialMediaTypeAdminVM(SocialMediaType mediaType)
    {
        this.Id = mediaType.Id;
        this.ImagePath = mediaType.ImagePath;
        this.TypeName = mediaType.TypeName;
    }

    public int Id { get; set; }
    public string TypeName { get; set; }
    public string ImagePath { get; set; }
}
