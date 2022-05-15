using AutoMapper;
using FluentValidation;
using LibraryMVC.Application.Interfaces.Mapping;

namespace LibraryMVC.Application.ViewModel.Borrower
{
    public class NewBorrowerVm : IMapFrom<LibraryMVC.Domain.Model.Borrower>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ParentName { get; set; }
        public string ParentLastName { get; set; }




        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewBorrowerVm, LibraryMVC.Domain.Model.Borrower>().ReverseMap();
        }
    }
    public class NewBorrowerValidation : AbstractValidator<NewBorrowerVm>
    {
        public NewBorrowerValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(1, 15);
            RuleFor(x => x.LastName).Length(1, 20);
        }
    }
}
