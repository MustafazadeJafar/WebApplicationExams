using Microsoft.AspNetCore.Mvc;
using WebApplication04.Areas.Admin.ViewModels.BlogAdminVMs;
using WebApplication04.Contexts;
using WebApplication04.Extensions;
using WebApplication04.Models;

namespace WebApplication04.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogController : Controller
{
    Server04DbContext _db { get; }

    public BlogController(Server04DbContext db)
    {
        _db = db;
    }

    // GET: BlogController
    public ActionResult Index()
    {
        return View(this._db.Blogs.Select(b => new BlogListItemVM(b)));
    }

    // GET: BlogController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: BlogController/Create
    [HttpPost]
    public async Task<ActionResult> Create(BlogCreateVM vm)
    {
        if (vm.ImageFile == null || !vm.ImageFile.IsCorrectType()) ModelState.AddModelError("", "File is not image");
        if (!ModelState.IsValid) return View(vm);

        Blog blog = await vm.ToBlog();

        await this._db.Blogs.AddAsync(blog);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: BlogController/Edit/5
    public async Task<ActionResult> Update(int id)
    {
        Blog blog = await this._db.Blogs.FindAsync(id);
        if (blog == null) return RedirectToAction(nameof(Index));
        return View(new BlogCreateVM(blog));
    }

    // POST: BlogController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Update(int id, BlogCreateVM vm)
    {
        if (vm.ImageFile != null && vm.ImageFile.IsCorrectType()) ModelState.AddModelError("", "File is not image");
        if (!ModelState.IsValid || vm.ImagePath == null) return View(vm);

        Blog blog = await vm.ToBlog();
        blog.Id = id;

        this._db.Blogs.Update(blog);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: BlogController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        Blog blog = await this._db.Blogs.FindAsync(id);
        if (blog == null) return NotFound();

        blog.IsDeleted = !blog.IsDeleted;

        this._db.Blogs.Update(blog);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
