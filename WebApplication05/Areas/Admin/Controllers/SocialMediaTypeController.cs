using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;
using WebApplication05.Contexts;
using WebApplication05.Extensions;
using WebApplication05.Modelsl;

namespace WebApplication05.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "SuperAdmin, Admin")]
public class SocialMediaTypeController : Controller
{
    Cial01DbContext _db { get; }

    public SocialMediaTypeController(Cial01DbContext db)
    {
        _db = db;
    }

    // GET: SocialMediaTypeController
    public ActionResult Index()
    {
        return View(this._db.SocialMediaTypes.Select(smt => new SocialMediaTypeAdminVM(smt)));
    }

    // GET: SocialMediaTypeController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: SocialMediaTypeController/Create
    [HttpPost]
    public async Task<ActionResult> CreateAsync(SocialMediaTypeCreateVM vm)
    {
        if (vm.ImageFile == null || !vm.ImageFile.IsCorrectType()) ModelState.AddModelError("", "No image provided");
        if (!ModelState.IsValid) return View(vm);

        SocialMediaType mediaType = await vm.ToMediaTypeAsync();
        await this._db.SocialMediaTypes.AddAsync(mediaType);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: SocialMediaTypeController/Delete/5
    public async Task<ActionResult> DeleteAsync(int id)
    {
        SocialMediaType mediaType = await this._db.SocialMediaTypes.FindAsync(id);
        if (mediaType == null) return NotFound();

        string path = Path.Combine(FileExtensions.RootPath, mediaType.ImagePath);

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
        
        this._db.SocialMediaTypes.Remove(mediaType);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
