using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication05.Areas.Admin.ViewModels.SocialMediaAdminVMs;
using WebApplication05.Contexts;
using WebApplication05.Models;

namespace WebApplication05.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "SuperAdmin, Admin")]
public class SocialMediaController : Controller
{
    Cial01DbContext _db { get; }
    UserManager<AppUser> _userManager {  get; }

    public SocialMediaController(Cial01DbContext db, UserManager<AppUser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    // GET: SocialMediaController
    public ActionResult Index()
    {
        return View(this._db.SocialMedias.Include(sm => sm.SocialMediaType).Include(sm => sm.AppUser).
            Select(sm => new SocialMediaAdminVM(sm)));
    }

    // GET: SocialMediaController/Create
    public ActionResult Create()
    {
        ViewBag.Types = new SelectList(this._db.SocialMediaTypes, "Id", "TypeName");
        //ViewBag.Users = new SelectList(this._db.AppUsers, "Id", "UserName");
        return View();
    }

    // POST: SocialMediaController/Create
    [HttpPost]
    public async Task<ActionResult> Create(SocialMediaCreateVM vm)
    {
        if (!await this._db.SocialMediaTypes.AnyAsync(smt => smt.Id == vm.SocialMediaTypeId)) ModelState.AddModelError("", "No such Social media type");
        if (!ModelState.IsValid)
        {
            ViewBag.Types = new SelectList(this._db.SocialMediaTypes, "Id", "TypeName");
            //ViewBag.Users = new SelectList(this._db.AppUsers, "Id", "UserName");
            return View(vm);
        }

        SocialMedia mediaLink = vm.ToMediaLink();
        mediaLink.AppUserId = (await this._userManager.FindByNameAsync(User.Identity.Name)).Id;

        await this._db.SocialMedias.AddAsync(mediaLink);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // GET: SocialMediaController/Edit/5
    public async Task<ActionResult> Edit(int id)
    {
        SocialMedia mediaLink = await this._db.SocialMedias.FindAsync(id);
        if (mediaLink == null) return NotFound();

        ViewBag.Types = new SelectList(this._db.SocialMediaTypes, "Id", "TypeName");
        //ViewBag.Users = new SelectList(this._db.AppUsers, "Id", "UserName");
        return View(new SocialMediaEditVM(mediaLink));
    }

    // POST: SocialMediaController/Edit/5
    [HttpPost]
    public async Task<ActionResult> Edit(int id, SocialMediaEditVM vm)
    {
        SocialMedia mediaLink = await this._db.SocialMedias.FindAsync(id);
        if (mediaLink == null) return NotFound();
        if (!await this._db.SocialMediaTypes.AnyAsync(smt => smt.Id == vm.TypeId)) ModelState.AddModelError("", "No such Social media type");
        if (!ModelState.IsValid)
        {
            ViewBag.Types = new SelectList(this._db.SocialMediaTypes, "Id", "TypeName");
            //ViewBag.Users = new SelectList(this._db.AppUsers, "Id", "UserName");
            return View(vm);
        }

        mediaLink.SocialMediaTypeId = vm.TypeId == null ? mediaLink.SocialMediaTypeId : (int)vm.TypeId;
        mediaLink.Link = vm.Link;

        this._db.Update(mediaLink);
        await this._db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    // GET: SocialMediaController/Delete/5
    public async Task<ActionResult> Delete(int id)
    {
        SocialMedia mediaLink = await this._db.SocialMedias.FindAsync(id);
        if (mediaLink == null) return NotFound();

        mediaLink.IsActive = !mediaLink.IsActive;
        this._db.Update(mediaLink);
        await this._db.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}
