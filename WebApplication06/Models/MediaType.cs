namespace WebApplication06.Models;

public class MediaType : BaseEntity
{
    public string Name { get; set; }
    public string ImagePath { get; set; }

    // //
    public IEnumerable<MediaLink>? MediaLinks { get; set; }
}
