namespace LibraryMVC.Domain.Model
{
    public class BorrowerContactInformation
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BorrowerRef { get; set; }
        public Borrower Borrower { get; set; }
    }
}
