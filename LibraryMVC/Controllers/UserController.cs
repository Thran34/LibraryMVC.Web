using LibraryMVC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IBorrowerService _borService;
        private readonly IItemService _itemService;
        private readonly IUserService _userService;

        public UserController(IBorrowerService borService, IItemService itemService, IUserService userService)
        {
            _borService = borService;
            _itemService = itemService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult GetBorrowers()
        {
            var model = _borService.GetAllBorrowersForList(2, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult GetBorrowers(int pageSize, int pageNo, string searchString)
        {
            if (pageNo == 0)
            {
                pageNo = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _borService.GetAllBorrowersForList(pageSize, pageNo, searchString);
            return View(model);
        }
        [HttpGet]
        public IActionResult GetBooks(int id)
        {
            var book = _itemService.GetAllBooksForList(2, 1, "");
            return View(book);
        }
        [HttpPost]
        public IActionResult GetBooks(int pageSize, int pageNo, string searchString)
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
        [HttpGet]
        public IActionResult BorrowBook(int id)
        {
            var borrower = _userService.GetBorrower(id);
            return View(borrower);
        }
    }
}
