using LibraryMVC.Domain.Model;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IItemRepository
    {
        void DeleteItem(int itemId);
        int AddItem(Item item);
        IQueryable<Item> GetAllActiveItems();
        IQueryable<Item> GetItemsByTypeId(int typeId);
        Item GetItem(int TypeId);

    }
}
