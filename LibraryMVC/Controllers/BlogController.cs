using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article(string article)
        {
            return View();
        }
    }
}
