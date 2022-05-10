using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Borrower;
using LibraryMVC.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMVC.Controllers
{
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
        public IActionResult AddBorrower(NewBorrowerVm model)
        {
            var id = _borService.AddBorrower(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddBorrower()
        {
            return View(new NewBorrowerVm());
        }


        [HttpGet]
        public IActionResult AddNewAddressForBorrower(int borrowerId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAddressForBorrower(Address model)
        {
            return View();
        }

        public IActionResult ViewBorrower(int borrowerId)
        {
            var borrowerModel = _borService.GetBorrowerDetails(borrowerId);
            return View(borrowerModel);
        }

        public IActionResult Delete(int id)
        {
            _borService.DeleteBorrower(id);
            return RedirectToAction("Index");
        }
    }
}
