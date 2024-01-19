using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication06.Models;
using WebApplication06.Models.Static;
using WebApplication06.ViewModels.Auth;

namespace WebApplication06.Controllers;

public class AuthController : Controller
{
    UserManager<AppUser> _userManager { get; }
    RoleManager<IdentityRole> _roleManager { get; }
    SignInManager<AppUser> _signInManager { get; }

    public AuthController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        this._roleManager = roleManager;
        this._userManager = userManager;
        this._signInManager = signInManager;
    }

    // GET: AuthController
    public ActionResult Register()
    {
        return View();
    }

    // POST: AuthController/Register
    [HttpPost]
    public async Task<ActionResult> Register(RegisterVM vm)
    {
        if (!ModelState.IsValid) return View(vm);
        if (await this._userManager.Users.AnyAsync(u => u.UserName == vm.UserName)) ModelState.AddModelError("", "Username already used");
        if (vm.Password != vm.ConfirmPassword) ModelState.AddModelError("", "Passwords dosen't match");
        if (!ModelState.IsValid) return View(vm);

        AppUser user = vm.ToAppUser();
        var result = await this._userManager.CreateAsync(user, vm.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(vm);
        }

        result = await this._userManager.AddToRoleAsync(user, nameof(AuthRoles.User));
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

    // GET: AuthController/Login
    public ActionResult Login()
    {
        return View();
    }

    // POST: AuthController/Login
    [HttpPost]
    public async Task<ActionResult> Login(LoginVM vm)
    {
        AppUser user = await this._userManager.FindByNameAsync(vm.UserName);
        if (user == null)
        {
            ModelState.AddModelError("", "Username or password is wrong");
            return View(vm);
        }

        if (!(await this._signInManager.PasswordSignInAsync(user, vm.Password, vm.RememberMe, true)).Succeeded)
        {
            ModelState.AddModelError("", "Username or password is wrong");
            return View(vm);
        }

        return RedirectToAction("Index", "Home");
    }

    [Authorize]
    // GET: AuthController/Logout
    public async Task<ActionResult> Logout()
    {
        await this._signInManager.SignOutAsync();
        return RedirectToAction(nameof(Login));
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
