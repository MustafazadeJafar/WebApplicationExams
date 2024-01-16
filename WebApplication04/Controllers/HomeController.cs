using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication04.Contexts;
using WebApplication04.Models;
using WebApplication04.ViewModels.Home;

namespace WebApplication04.Controllers
{
    public class HomeController : Controller
    {
        Server04DbContext _db { get; }


        public HomeController(Server04DbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(new HomePageVM());
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
}