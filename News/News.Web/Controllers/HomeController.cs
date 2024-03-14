namespace News.Web.Controllers;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using News.DAL.Models;
using News.Web.Models;

using Newtonsoft.Json;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var articles = new List<ArticleViewModel>();
        for (int i = 0; i < 6; i++)
        {
            articles.Add(new ArticleViewModel { Content = $"Article{i + 1}", PublishedDate = DateTime.Now, });
        }

        var userDataJson = HttpContext.Session.GetString("UserData");
        if (!string.IsNullOrEmpty(userDataJson))
        {
            var user = JsonConvert.DeserializeObject<User>(userDataJson);
            ViewData["FirstName"] = user.FirstName;
        }
        return View(articles);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}