using Microsoft.EntityFrameworkCore;
using WebApplication05.Contexts;
using WebApplication05.Models;
using WebApplication05.ViewModels.SocialMediaVMs;

namespace WebApplication05.ViewModels.AppUserVMs;

public class AppUserVM
{
    //public static IEnumerable<AppUserVM> MultipleCtor(DbSet<AppUser> users, bool needActive = true)
    //{
    //    return users.Include("SocialMedias").Include("SocialMediaType").Select(u => new AppUserVM()
    //    {
    //        Fullname = u.UserName,
    //        SocialMediaVMs = u.SocialMedias.Where(s  => s.IsActive || !needActive).Select(s => new SocialMediaVM()
    //        {
    //            Link = s.Link,
    //            MediaType = s.SocialMediaType.TypeName
    //        })
    //    });
    //}

    public AppUserVM(AppUser user, bool needActive = true)
    {
        this.Fullname = user.UserName;
        this.SocialMediaVMs = user.SocialMedias?.Where(s => s.IsActive || !needActive).Select(s => new SocialMediaVM(s));
    }

    public string Fullname { get; set; }
    public string ImagePath { get; set; } = "images/img-7.png";
    public IEnumerable<SocialMediaVM> SocialMediaVMs { get; set; }
}
