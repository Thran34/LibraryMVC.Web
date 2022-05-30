using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Item;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Model;

namespace LibraryMVC.Application.Services
{

    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IBorrowerRepository _borRepo;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepo, IBorrowerRepository borRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
            _borRepo = borRepo;
            _mapper = mapper;
        }
        public int AddBook(NewItemVm item)
        {
            var borr = _mapper.Map<Item>(item);
            var id = _itemRepo.AddItem(borr);
            return id;
        }
        public void DeleteBook(int id)
        {
            _itemRepo.DeleteItem(id);
        }
        public ListItemForListVm GetAllBooksForList(int pageSize, int pageNo, string searchString)
        {
            var items = _itemRepo.GetAllActiveItems().Where(p => p.Name.StartsWith(searchString))
             .ProjectTo<ItemForListVm>(_mapper.ConfigurationProvider).ToList();
            var itemsToShow = items.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var itemList = new ListItemForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Items = itemsToShow,
                Count = items.Count
            };
            return itemList;
        }
        public ItemDetailsVm GetItemDetails(int itemId)
        {
            var item = _itemRepo.GetItem(itemId);
            var itemVm = new ItemDetailsVm();
            itemVm.Id = item.Id;
            itemVm.AuthorFullName = item.AuthorName + " " + item.AuthorLastName;
            return itemVm;
        }
        public Item GetBookForBorrow(int id)
        {
            var book = _itemRepo.GetItem(id);
            var bookVm = _mapper.Map<Item>(book);
            return bookVm;
        }
        public void BorrowBook(Item model)
        {
            var book = _mapper.Map<Item>(model);
            _itemRepo.BorrowBook(book);
        }
    }
}

