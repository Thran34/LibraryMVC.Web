namespace LibraryMVC.Application.ViewModel.Item
{
    public class ListItemForListVm
    {
        public List<ItemForListVm> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
