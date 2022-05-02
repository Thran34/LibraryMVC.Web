namespace LibraryMVC.Domain.Model
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string ContactDetailInformation { get; set; }
        public ContactDetailType ContactDetailType { get; set; }
        public int BorrowerId { get; set; }
        public Borrower Borrower { get; set; }
    }
}
