using WebApplication06.Models;

namespace WebApplication06.ViewModels.Home;

public class UserMediaVM
{
    public string Link { get; set; }
    public string ImagePath { get; set; }

    public UserMediaVM(MediaLink mediaLink)
    {
        this.Link = mediaLink.Link;
        this.ImagePath = mediaLink.MediaType.ImagePath;
    }
}
