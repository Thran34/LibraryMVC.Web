using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;
using System.ComponentModel;

namespace LibraryMVC.Application.ViewModel.Item
{
    public class ItemDetailsVm : IMapFrom<LibraryMVC.Domain.Model.Item>
    {
        public int Id { get; set; }

        [DisplayName("Author")]
        public string AuthorFullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Item, ItemDetailsVm>()
                .ForMember(s => s.AuthorFullName, opt => opt.MapFrom(d => d.AuthorName + " " + d.AuthorLastName));
        }
    }
}
