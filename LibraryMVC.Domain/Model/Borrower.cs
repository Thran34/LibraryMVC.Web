namespace LibraryMVC.Domain.Model
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        public string? ParentName { get; set; }
        public string? ParentLastName { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<BorrowerContactInformation> BorrowerContactInformation { get; set; }
        public ICollection<Address> Addresses { get; set; }



    }
}
