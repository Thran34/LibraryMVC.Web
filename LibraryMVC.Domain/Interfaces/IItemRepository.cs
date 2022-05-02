using LibraryMVC.Domain.Model;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IItemRepository
    {
        void DeleteItem(int itemId);
        int AddItem(Item item);
        IQueryable<Item> GetItemsByTypeId(int typeId);
        Item GetItemById(int itemId);
        IQueryable<Tag> GetAllTags();
        IQueryable<Domain.Model.Type> GetAllTypes();
    }
}
