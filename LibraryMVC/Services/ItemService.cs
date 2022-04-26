using LibraryMVC.Models;

namespace LibraryMVC
{

    public class ItemService : IItemService
    {

        public List<Item> items = new List<Item>();


        public Item AddBook(Item item)
        {
            items.Add(item);
            return item;
        }
        public void DeleteBook(Item item)
        {
            items.Remove(item);
        }
        public Item GetBook(int id)
        {
            return items.SingleOrDefault(x => x.Id == id);
        }
        public List<Item> GetBooks()
        {
            return items;
        }
    }
}

