using System.ComponentModel.DataAnnotations;

namespace WebApplication06.Areas.Admin.ViewModels.MediaTypeA;

public class MediaTypeCreateAVM
{
    [MinLength(3), MaxLength(31)]
    public string Name { get; set; }
    public IFormFile ImageFile { get; set; }
}
