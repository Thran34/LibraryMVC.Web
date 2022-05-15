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
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepo, IMapper mapper)
        {
            _itemRepo = itemRepo;
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
    }
}

