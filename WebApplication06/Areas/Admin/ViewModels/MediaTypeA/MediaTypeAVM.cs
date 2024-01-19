using WebApplication06.Models;

namespace WebApplication06.Areas.Admin.ViewModels.MediaTypeA;

public class MediaTypeAVM : BaseAVM
{
    public string Name { get; set; }
    public string ImagePath { get; set; }

    public MediaTypeAVM(MediaType mediaType)
    {
        this.Id = mediaType.Id;
        this.IsActive = mediaType.IsActive;
        this.Name = mediaType.Name;
        this.ImagePath = mediaType.ImagePath;
    }
}
