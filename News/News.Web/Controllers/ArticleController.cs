namespace News.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
