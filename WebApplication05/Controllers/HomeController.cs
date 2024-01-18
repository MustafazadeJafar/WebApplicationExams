using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication05.Contexts;
using WebApplication05.Models;
using WebApplication05.ViewModels.AppUserVMs;

namespace WebApplication05.Controllers;

public class HomeController : Controller
{
    Cial01DbContext _db { get; }

    public HomeController(Cial01DbContext db)
    {
        this._db = db;
    }

    public IActionResult Index()
    {
        return View(this._db.AppUsers.Where(u => u.IsWorker).Take(4).Include(u => u.SocialMedias).ThenInclude(s => s.SocialMediaType).
            OrderByDescending(u => u.Id).Select(u => new AppUserVM(u, true)));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}