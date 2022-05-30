using LibraryMVC.Domain.Model;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IItemRepository
    {
        void DeleteItem(int itemId);
        int AddItem(Item item);
        IQueryable<Item> GetAllActiveItems();
        Item GetItem(int TypeId);
        public void BorrowBook(Item item);
    }
}
