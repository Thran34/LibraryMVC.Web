namespace LibraryMVC.Domain.Model
{

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }

        public virtual ICollection<ItemTag> ItemTags { get; set; }
    }
}
