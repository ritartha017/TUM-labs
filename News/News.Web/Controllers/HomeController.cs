namespace News.Web.Controllers;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using News.Web.Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var articles = new List<Article>();
        for (int i = 0; i < 6; i++)
        {
            articles.Add(new Article { Content = $"Article{i + 1}", PublishedDate = DateTime.Now, });
        }
        return View(articles);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}