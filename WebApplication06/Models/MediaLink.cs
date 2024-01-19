namespace WebApplication06.Models;

public class MediaLink : BaseEntity
{
    public int MediaTypeId { get; set; }
    public string AppUserId { get; set; }

    // //
    public string Link { get; set; }

    // //
    public MediaType? MediaType { get; set; }
    public AppUser? AppUser { get; set; }
}
