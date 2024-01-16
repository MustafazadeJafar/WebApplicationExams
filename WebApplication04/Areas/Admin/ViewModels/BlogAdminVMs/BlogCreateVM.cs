using WebApplication04.Extensions;
using WebApplication04.Models;

namespace WebApplication04.Areas.Admin.ViewModels.BlogAdminVMs;

public class BlogCreateVM
{
    public string Title { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImagePath { get; set; }

    public BlogCreateVM() { }

    public BlogCreateVM(Blog blog)
    {
        Title = blog.Title;
        ImagePath = blog.ImagePath;
    }

    public async Task<Blog> ToBlog()
    {
        return new()
        {
            Title = this.Title,
            ImagePath = this.ImageFile == null ? this.ImagePath : await this.ImageFile.SaveAsync(),
        };
    }
}
