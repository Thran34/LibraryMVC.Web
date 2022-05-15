using AutoMapper;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class BorrowerForListVm : IMapFrom<LibraryMVC.Domain.Model.Borrower>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LibraryMVC.Domain.Model.Borrower, BorrowerForListVm>();


        }
    }
}
