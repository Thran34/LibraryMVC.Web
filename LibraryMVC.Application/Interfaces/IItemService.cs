using LibraryMVC.Application.ViewModel.Item;

namespace LibraryMVC.Application.Interfaces
{
    public interface IItemService
    {
        public int AddBook(NewItemVm item);
        public void DeleteBook(int id);
        public ListItemForListVm GetAllBooksForList(int pageSize, int pageNo, string searchString);
        public ItemDetailsVm GetItemDetails(int itemId);
    }
}