using LibraryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IItemService _itemService;
        public HomeController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Jestem w Home/Index");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        [Route("Items/list")]
        public IActionResult ViewListOfItems()
        {
            var book = _itemService.GetBooks();
            return View(book);
        }
        [HttpPost]
        [Route("Items/kwe")]
        public IActionResult AddBook(Item item)
        {
            _itemService.AddBook(item);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var book = _itemService.GetBook(id);
            if (book != null)
            {
                _itemService.DeleteBook(book);
                return Ok("Succesfully Removed");
            }
            else
            {
                return NotFound($"Book with Id {id} was not found!");
            }
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}