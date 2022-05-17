namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class AddressForListVm
    {
        public int AddressId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? TelNumber { get; set; }
        public string Email { get; set; }
        public int? BorrowerId { get; set; }
    }
}