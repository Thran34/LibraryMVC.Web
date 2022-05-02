namespace LibraryMVC.Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ItemTag> ItemTags { get; set; }
    }
}
