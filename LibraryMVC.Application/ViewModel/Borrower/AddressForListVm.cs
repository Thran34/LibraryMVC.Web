using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class AddressForListVm : IMapFrom<LibraryMVC.Domain.Model.Borrower>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Borrower, AddressForListVm>()
            .ForMember(a => a.Country, opt => opt.MapFrom(b => b.Addresses))
            .ForMember(a => a.City, opt => opt.MapFrom(b => b.Addresses))
            .ForMember(a => a.Street, opt => opt.MapFrom(b => b.Addresses));

        }
    }
}