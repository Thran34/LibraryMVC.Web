using LibraryMVC.Application.ViewModel.Item;
using LibraryMVC.Domain.Model;

namespace LibraryMVC.Application.Interfaces
{
    public interface IItemService
    {
        public int AddBook(NewItemVm item);
        public void DeleteBook(int id);
        public ListItemForListVm GetAllBooksForList(int pageSize, int pageNo, string searchString);
        public ItemDetailsVm GetItemDetails(int itemId);
        public Item GetBookForBorrow(int id);
        public void BorrowBook(Item model);

    }
}