using WebApplication04.Models;
using WebApplication04.ViewModels.BlogVMs;

namespace WebApplication04.Areas.Admin.ViewModels.BlogAdminVMs;

public class BlogListItemVM : BlogVM
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }

    public BlogListItemVM() { }
    public BlogListItemVM(Blog blog)
    {
        Id = blog.Id;
        Title = blog.Title;
        ImagePath = blog.ImagePath;
        IsDeleted = blog.IsDeleted;
    }
}
