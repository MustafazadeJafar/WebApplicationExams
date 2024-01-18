using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication05.Models;
using WebApplication05.Models.Static;
using WebApplication05.ViewModels.AuthVMs;

namespace WebApplication05.Controllers;

public class AuthController : Controller
{
    UserManager<AppUser> _userManager { get; }
    RoleManager<IdentityRole> _roleManager { get; }
    SignInManager<AppUser> _signInManager { get; }

    public AuthController(SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        this._signInManager = signInManager;
        this._roleManager = roleManager;
        this._userManager = userManager;
    }

    // GET: AuthController/Register
    public ActionResult Register()
    {
        return View();
    }

    // GET: AuthController/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: AuthController/Register
    [HttpPost]
    public async Task<ActionResult> Register(RegisterVM vm)
    {
        if (await this._userManager.FindByNameAsync(vm.UserName) != null) ModelState.AddModelError("", "Username already used");
        if (vm.Password != vm.ConfirmPassword) ModelState.AddModelError("", "Passwords dont match"); 
        if (!ModelState.IsValid) return View(vm);

        AppUser user = vm.ToAppUser();
        user.IsWorker = false;

        var result = await this._userManager.CreateAsync(user, vm.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(vm);
        }

        result = await this._userManager.AddToRoleAsync(user, AuthRoles.User.ToString());
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(vm);
        }

        return RedirectToAction(nameof(Login));
    }

    // POST: AuthController/Login
    [HttpPost]
    public async Task<ActionResult> Login(LoginVM vm)
    {
        bool doRemember = true;
        AppUser user = await this._userManager.FindByNameAsync(vm.UserName);
        if (user == null)
        {
            ModelState.AddModelError("", "Username or password is wrong");
            return View(vm);
        }

        var result = await this._signInManager.PasswordSignInAsync(user, vm.Password, doRemember, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username or password is wrong");
            return View(vm);
        }

        return RedirectToAction("Index", "Home");
    }

    // GET: AuthController/Logout
    [Authorize]
    public async Task<ActionResult> Logout()
    {
        await this._signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    // GET: AuthController/UpdateRoles
    public async Task<ActionResult> UpdateRoles()
    {
        foreach (var item in Enum.GetNames<AuthRoles>())
        {
            if (!await this._roleManager.RoleExistsAsync(item))
            {
                await this._roleManager.CreateAsync(new IdentityRole(item));
            }
        }

        return Ok();
    }
}
