using System.Text;
using WebApplication06.Models;

namespace WebApplication06.ViewModels.Home;

public class InstructorVM
{
    public string FullName { get; set; }
    public string ImagePath { get; set; }
    public IEnumerable<string> Roles { get; set; }
    public IEnumerable<UserMediaVM> UserMedias { get; set; }

    public InstructorVM(AppUser user)
    {
        this.FullName = user.FullName;
        this.ImagePath = user.ImagePath;
        this.Roles = user.InstructorUserRoles.Select(iur => iur.InstructorRole.Role);
        this.UserMedias = user.MediaLinks.Select(ml => new UserMediaVM(ml));
    }

    public string RolesTagValue()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var role in this.Roles)
        {
            sb.Append(role);
            sb.Append(' ');
            sb.Append('&');
            sb.Append(' ');
        }
        return sb.ToString().Trim();
    }
}
