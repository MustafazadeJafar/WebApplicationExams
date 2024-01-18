using WebApplication05.Modelsl;

namespace WebApplication05.Models;

public class SocialMedia : BaseEntity
{
    public string AppUserId { get; set; }
    public int SocialMediaTypeId { get; set; }

    // //
    public string Link { get; set; }

    // //
    public AppUser? AppUser { get; set; }
    public SocialMediaType? SocialMediaType { get; set; }
}
