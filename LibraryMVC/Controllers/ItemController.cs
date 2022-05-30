using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Item;
using LibraryMVC.Domain.Model;
using LibraryMVC.Filters;
using LibraryMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var book = _itemService.GetAllBooksForList(10, 1, "");
            return View(book);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int pageNo, string searchString)
        {
            if (pageNo == 0)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _itemService.GetAllBooksForList(pageSize, pageNo, searchString);
            return View(model);
        }
        [HttpPost]
        public IActionResult AddBook(NewItemVm item)
        {
            _itemService.AddBook(item);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View(new NewItemVm());
        }
        [HttpGet]
        public IActionResult ViewBook(int id)
        {
            var itemModel = _itemService.GetItemDetails(id);
            return View(itemModel);
        }
        public IActionResult Delete(int id)
        {
            _itemService.DeleteBook(id);
            return RedirectToAction("Index");
        }
        [CheckPermissions("Read")]
        [HttpPost]
        public IActionResult BorrowBook(Item model)
        {
            _itemService.BorrowBook(model);
            return RedirectToAction("Index");
        }
        [CheckPermissions("Read")]
        [HttpGet]
        public IActionResult BorrowBook(int id)
        {
            var book = _itemService.GetBookForBorrow(id);
            return View(book);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}