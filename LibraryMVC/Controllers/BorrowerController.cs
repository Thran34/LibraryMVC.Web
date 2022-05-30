using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Borrower;
using Microsoft.AspNetCore.Authorization;
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
        public BorrowerController(IBorrowerService borService)
        {
            _borService = borService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _borService.GetAllBorrowersForList(10, 1, "");
            return View(model);
        }
        [Authorize(Policy = "CanViewBorrowers")]
        [HttpPost]
        public IActionResult Index(int pageSize = 1, int pageNo = 1, string searchString = "")
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
        [Authorize]
        [HttpGet]
        public IActionResult EditBorrower(int id)
        {
            var borrower = _borService.GetBorrowerForEdit(id);
            return View(borrower);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditAddress(NewAddresVm model)
        {
            _borService.UpdateAddress(model);
            return RedirectToAction("Index");
        }
        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult AddNewAddressForBorrower(NewAddresVm model)
        {
            _borService.AddAddress(model);
            return RedirectToAction("index");
        }
        [Authorize]

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
        [Authorize]
        public IActionResult Delete(int id)
        {
            _borService.DeleteBorrower(id);
            return RedirectToAction("Index");
        }
    }
}
