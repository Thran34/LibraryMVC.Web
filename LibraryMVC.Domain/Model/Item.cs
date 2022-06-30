namespace LibraryMVC.Domain.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public bool IsActive { get; set; } = true;
        public int? BorrowerId { get; set; }
        public DateTime DeadLine { get; set; }

    }
}
