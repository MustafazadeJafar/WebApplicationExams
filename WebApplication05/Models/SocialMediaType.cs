using System.ComponentModel.DataAnnotations;
using WebApplication05.Models;

namespace WebApplication05.Modelsl;

public class SocialMediaType : BaseEntity
{
    [MaxLength(31)]
    public string TypeName { get; set; }
    public string ImagePath { get; set; }

    // //
    public IEnumerable<SocialMedia>? SocialMedias { get; set; }
}
