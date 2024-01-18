using WebApplication05.Extensions;
using WebApplication05.Modelsl;

namespace WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;

public class SocialMediaTypeCreateVM
{
    public string TypeName { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }

    public async Task<SocialMediaType> ToMediaTypeAsync()
    {
        return new()
        {
            TypeName = this.TypeName,
            ImagePath = await this.ImageFile.SaveAsync(),
        };
    }
}
