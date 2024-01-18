using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using WebApplication05.Areas.Admin.ViewModels.UsersAdminVMs;
using WebApplication05.Contexts;
using WebApplication05.Extensions;
using WebApplication05.Models;

namespace WebApplication05.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "SuperAdmin, Admin")]
public class UsersController : Controller
{
    Cial01DbContext _db { get;  }

    public UsersController(Cial01DbContext db)
    {
        _db = db;
    }

    // GET: UsersController
    public ActionResult Index()
    {
        return View(this._db.AppUsers.Select(u => new UserListItemVM(u)));
    }

    // GET: UsersController/Delete/5
    public async Task<ActionResult> DeleteAsync(string id)
    {
        AppUser user = await this._db.AppUsers.FindAsync(id);
        if (user == null) return NotFound();

        user.IsWorker = !user.IsWorker;
        this._db.Update(user);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: SocialMediaController/Edit/5
    public ActionResult Edit(string id)
    {
        return View();
    }

    // POST: SocialMediaController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(string id, UserEditVM vm)
    {
        AppUser user = await this._db.AppUsers.FindAsync(id);
        if (user == null) return NotFound();

        if (!vm.ImageFile.IsCorrectType())
        {
            ModelState.AddModelError("", "No image provided");
            return View(vm);
        }

        string path = Path.Combine(FileExtensions.RootPath, vm.ImagePath);
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }
        user.ImagePath = await vm.ImageFile.SaveAsync();

        this._db.Update(user);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
