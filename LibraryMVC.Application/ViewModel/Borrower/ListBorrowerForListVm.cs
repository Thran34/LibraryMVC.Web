namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class ListBorrowerForListVm
    {
        public List<BorrowerForListVm> Borrowers { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
