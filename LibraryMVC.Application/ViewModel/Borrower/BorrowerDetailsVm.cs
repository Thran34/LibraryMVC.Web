using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class BorrowerDetailsVm : IMapFrom<LibraryMVC.Domain.Model.Borrower>
    {
        public int Id { get; set; }
        public string ParentFullName { get; set; }
        public string FirstLineOfContactInformation { get; set; }
        public List<AddressForListVm> Addresses { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Borrower, BorrowerDetailsVm>()
                .ForMember(s => s.ParentFullName, opt => opt.MapFrom(d => d.ParentName + " " + d.ParentLastName))
                .ForMember(s => s.FirstLineOfContactInformation, opt => opt.MapFrom
                (d => d.BorrowerContactInformation.FirstName + " " +
                d.BorrowerContactInformation.LastName))
                .ForMember(s => s.Addresses, opt => opt.AllowNull());
        }
    }
}
