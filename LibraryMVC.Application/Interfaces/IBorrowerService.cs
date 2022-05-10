using LibraryMVC.Application.ViewModel.Borrower;

namespace LibraryMVC.Application.Interfaces
{
    public interface IBorrowerService
    {
        ListBorrowerForListVm GetAllBorrowersForList(int pageSize, int pageNo, string searchString);
        int AddBorrower(NewBorrowerVm borrower);
        BorrowerDetailsVm GetBorrowerDetails(int borrowerId);
        void DeleteBorrower(int id);
        NewBorrowerVm GetBorrowerForEdit(int id);
        void UpdateBorrower(NewBorrowerVm model);
    }
}
