using AP2_MVC_DOTNET.Models;
using AP2_MVC_DOTNET.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AP2_MVC_DOTNET.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<Medecin> _signInManager;
    private readonly UserManager<Medecin> _userManager;

    public AccountController(SignInManager<Medecin> signInManager, UserManager<Medecin> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public IActionResult Login()
    {
        return View(); // Affiche la vue Login
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }


    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new Medecin() { UserName = model.UserName, Email = model.Email, Nom_m = model.Nom_m, Prenom_m = model.Prenom_m, Date_naissance_m  = model.Date_naissance_m};
            var result = await _userManager.CreateAsync(user, model.PasswordHash);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

   
}