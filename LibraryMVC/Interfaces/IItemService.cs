using LibraryMVC.Models;

namespace LibraryMVC
{
    public interface IItemService
    {
        Item AddBook(Item item);
        void DeleteBook(Item item);
        Item GetBook(int id);
        List<Item> GetBooks();
    }
}