using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication06.Areas.Admin.ViewModels.MediaTypeA;
using WebApplication06.Conntexts;
using WebApplication06.Extensions;

namespace WebApplication06.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "SuperAdmin, Admin")]
public class MediaTypeController : Controller
{
    Edukate01DbContext _context {  get; }

    public MediaTypeController(Edukate01DbContext context)
    {
        _context = context;
    }

    // GET: MediaTypeController
    public ActionResult Index()
    {
        return View(this._context.MediaTypes.Select(mt => new MediaTypeAVM(mt)));
    }

    // GET: MediaTypeController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: MediaTypeController/Create
    [HttpPost]
    public ActionResult Create(MediaTypeCreateAVM vm)
    {
        if (!ModelState.IsValid) return View(vm);
        if (vm.ImageFile == null || !vm.ImageFile.IsCorrectType()) ModelState.AddModelError("", "No Image Provided");


    }

    // GET: MediaTypeController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: MediaTypeController/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: MediaTypeController/Toggle/5
    public ActionResult Toggle(int id)
    {
        return View();
    }
}
