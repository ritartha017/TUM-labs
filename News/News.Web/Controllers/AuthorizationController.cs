namespace News.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using News.BL.Interfaces;
using News.Web.Models;

using Newtonsoft.Json;

public class AuthorizationController : Controller
{
    private readonly ILogger<AuthorizationController> logger;
    private readonly IUserBL userBL;

    public AuthorizationController(ILogger<AuthorizationController> logger,
        IUserBL userBL)
    {
        this.logger = logger;
        this.userBL = userBL;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            int? userId = this.userBL.Authenticate(model.Email, model.Password);
            if (userId != null)
            {
                //return View(userBL.GetUserById(userId.Value));
                var user = userBL.GetUserById(userId.Value);
                var userDataJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("UserData", userDataJson);
                return RedirectToAction("Index", "Home");
            }
        }
        return View(null);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = this.userBL.Register(model.FirstName, model.LastName, model.Email, model.Password);
            if (userId != null)
            {
                var user = userBL.GetUserById(userId.Value);
                var userDataJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("UserData", userDataJson);
                return RedirectToAction("Index", "Home");
            }
        }
        return View(null);
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.SetString("UserData", "");
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Route("Logout")]
    public IActionResult LogoutPost()
    {
        HttpContext.Session.SetString("UserData", "");
        return RedirectToAction("Index", "Home");
    }
}
