using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Borrower;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
    /*
    albo połączyć id adresu i id pożyczającego w jedno
    albo sprawić by przycisk przekazywał id adresu a nie id pożyczającego 

     stworzyć model, kontroler oraz serwis i repo dla ksiązek
     utworzyc zależności między ksiązkami i pożyczającymi 
       (kto jaka ksiązka, ile czasu pozostało czy po terminie, kary za przedłużenie )
     stworzyć ładny layout
     */
    public class BorrowerController : Controller
    {
        private readonly IBorrowerService _borService;
        private readonly IItemService _itemService;
        public BorrowerController(IBorrowerService borService, IItemService itemService)
        {
            _borService = borService;
            _itemService = itemService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _borService.GetAllBorrowersForList(2, 1, "");
            return View(model);
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
            var model = _borService.GetAllBorrowersForList(pageSize, pageNo, searchString);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditBorrower(NewBorrowerVm model)
        {
            _borService.UpdateBorrower(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditBorrower(int id)
        {
            var borrower = _borService.GetBorrowerForEdit(id);
            return View(borrower);
        }
        [HttpPost]
        public IActionResult EditAddress(NewAddresVm model)
        {
            _borService.UpdateAddress(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAddress(int id)
        {
            var address = _borService.GetAddressForEdit(id);
            return View(address);
        }
        [HttpPost]
        public IActionResult AddBorrower(NewBorrowerVm model)
        {
            _borService.AddBorrower(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBorrower()
        {
            return View(new NewBorrowerVm());
        }

        [HttpPost]
        public IActionResult AddNewAddressForBorrower(NewAddresVm model)
        {
            _borService.AddAddress(model);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult AddNewAddressForBorrower(int id)
        {
            return View(new NewAddresVm()
            {
                BorrowerId = id
            });
        }
        [HttpGet]
        public IActionResult ViewBorrower(int id)
        {
            var borrowerModel = _borService.GetBorrowerDetails(id);
            return View(borrowerModel);
        }

        public IActionResult Delete(int id)
        {
            _borService.DeleteBorrower(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult BorrowBook()
        {
            var book = _itemService.GetAllBooksForList(2, 1, "");
            return View(book);
        }
    }
}
