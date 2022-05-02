namespace LibraryMVC.Domain.Model
{
    public class BorrowerContactInformation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int BorrowerRef { get; set; }
        public Borrower Borrower { get; set; }
    }
}
