using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Item
{
    public class ItemForListVm : IMapFrom<LibraryMVC.Domain.Model.Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string AuthorName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFullName { get; set; }
        public int? borrowerId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Item, ItemForListVm>()
               .ForMember(s => s.AuthorFullName, opt => opt.MapFrom(d => d.AuthorName + " " + d.AuthorLastName));
        }
    }
}
