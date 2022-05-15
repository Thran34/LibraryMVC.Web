using AutoMapper;
using FluentValidation;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class NewAddresVm : IMapFrom<LibraryMVC.Domain.Model.Address>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int? BorrowerId { get; set; }
        public int TelNumber { get; set; }
        public string Email { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAddresVm, LibraryMVC.Domain.Model.Address>().ReverseMap();
        }
        public class NewAddressValidation : AbstractValidator<NewAddresVm>
        {
            public NewAddressValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Street).Length(1, 20);
                RuleFor(x => x.Country).Length(1, 20);
                RuleFor(x => x.City).Length(1, 20);
            }
        }
    }
}
