using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;
using LibraryMVC.Application.ViewModel.Item;
using System.ComponentModel;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class BorrowerDetailsVm : IMapFrom<LibraryMVC.Domain.Model.Borrower>
    {
        public int Id { get; set; }
        [DisplayName("Parent full name")]
        public string ParentFullName { get; set; }

        [DisplayName("Contact informations")]
        public List<AddressForListVm> Addresses { get; set; }
        public List<ItemForListVm> Books { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Borrower, BorrowerDetailsVm>()
                .ForMember(s => s.ParentFullName, opt => opt.MapFrom(d => d.ParentName + " " + d.ParentLastName))
                .ForMember(s => s.Addresses, opt => opt.MapFrom(d => d.Addresses));





        }
    }
}
