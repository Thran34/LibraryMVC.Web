using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Item
{
    public class NewItemVm : IMapFrom<LibraryMVC.Domain.Model.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public int BorrowerId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewItemVm, LibraryMVC.Domain.Model.Item>().ReverseMap();
        }

    }
}
