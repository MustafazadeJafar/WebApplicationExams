using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication06.Conntexts;
using WebApplication06.Models;
using WebApplication06.ViewModels.Home;

namespace WebApplication06.Controllers
{
    public class HomeController : Controller
    {
        Edukate01DbContext _context {  get; }

        public HomeController(Edukate01DbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View(this._context.AppUsers.Where(u => u.IsInstructor).
                Include(u => u.MediaLinks).ThenInclude(ml => ml.MediaType).
                Select(u => new InstructorVM(u)));
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