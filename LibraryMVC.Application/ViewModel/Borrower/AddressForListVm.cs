using AutoMapper;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class AddressForListVm
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Borrower, AddressForListVm>();
        }

    }
}