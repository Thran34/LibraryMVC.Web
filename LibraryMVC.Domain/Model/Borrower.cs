namespace LibraryMVC.Domain.Model
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public Item Book { get; set; }

        public BorrowerContactInformation BorrowerContactInformation { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
