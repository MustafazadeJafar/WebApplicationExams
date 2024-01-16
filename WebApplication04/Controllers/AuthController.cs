using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication04.Models;
using WebApplication04.ViewModels.Auth;

namespace WebApplication04.Controllers;

public class AuthController : Controller
{
    UserManager<AppUser> _userManager { get; }
    RoleManager<IdentityRole> _roleManager { get; }

    public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // GET: AuthController/Register
    public ActionResult Register()
    {
        return View();
    }

    //Post: AuthController/Register
    [HttpPost]
    public ActionResult Register(RegisterVM vm)
    {
        if (!ModelState.IsValid) return View(vm);
        


        return RedirectToAction(nameof(Login));
    }

    // GET: AuthController/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: AuthController/Login
    [HttpPost]
    public ActionResult Login(LoginVM vm)
    {
        return RedirectToAction("Index", "Home");
    }

    // GET: AuthController/Logout
    public ActionResult Logout()
    {
        return RedirectToAction(nameof(Register));
    }
}
