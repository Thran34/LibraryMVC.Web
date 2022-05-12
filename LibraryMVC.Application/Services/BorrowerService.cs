using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Borrower;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Model;

namespace LibraryMVC.Application.Services
{
    public class BorrowerService : IBorrowerService
    {

        private readonly IBorrowerRepository _borrowerRepo;
        private readonly IMapper _mapper;

        public BorrowerService(IBorrowerRepository borrowerRepo, IMapper mapper)
        {
            _borrowerRepo = borrowerRepo;
            _mapper = mapper;
        }
        public ListBorrowerForListVm GetAllBorrowersForList(int pageSize, int pageNo, string searchString)
        {
            var borrowers = _borrowerRepo.GetAllActiveBorrowers().Where(p => p.Name.StartsWith(searchString))
               .ProjectTo<BorrowerForListVm>(_mapper.ConfigurationProvider).ToList();

            var borrowersToShow = borrowers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();


            var borrowerList = new ListBorrowerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Borrowers = borrowersToShow,
                Count = borrowers.Count
            };
            return borrowerList;
            /* ListBorrowerForListVm result = new ListBorrowerForListVm();
             result.Borrowers = new List<BorrowerForListVm>();
             foreach (var borrower in borrowers)
             {
                 var borVm = new BorrowerForListVm()
                 {
                     Id = borrower.Id,
                     Name = borrower.Name,
                     LastName = borrower.LastName,
                 };                                          <= niepotrzebne,
                                                        automapper robi to za mnie
                 result.Borrowers.Add(borVm);
             }
             result.Count = result.Borrowers.Count;
            return result;*/
        }

        public BorrowerDetailsVm GetBorrowerDetails(int borrowerId)
        {
            var borrower = _borrowerRepo.GetBorrower(borrowerId);
            var borrowerVm = new BorrowerDetailsVm();
            borrowerVm.Id = borrower.Id;
            borrower.Name = borrower.Name;
            borrower.LastName = borrower.LastName;
            borrowerVm.ParentFullName = borrower.ParentName + " " + borrower.ParentLastName;

            borrowerVm.Addresses = new List<AddressForListVm>();

            foreach (var address in borrower.Addresses)
            {
                var add = new AddressForListVm()
                {
                    Id = address.Id,
                    City = address.City,
                    Country = address.Country,
                    Street = address.Street,
                };
                borrowerVm.Addresses.Add(add);
            }
            return borrowerVm;
        }
        /*
        public AddressForListVm GetBorrowerAddress(int borrowerId)
        {
            var borrower = _borrowerRepo.GetBorrower(borrowerId);
            var addressVm = new AddressForListVm();
            addressVm.Id = borrower.Id;
            addressVm.City = borrower.
            return addressVm;
        }*/
        public int AddBorrower(NewBorrowerVm borrower)
        {
            var borr = _mapper.Map<Borrower>(borrower);
            var id = _borrowerRepo.AddBorrower(borr);
            return id;
        }

        public void DeleteBorrower(int id)
        {
            _borrowerRepo.DeleteBorrower(id);
        }
        public NewBorrowerVm GetBorrowerForEdit(int id)
        {
            var borrower = _borrowerRepo.GetBorrower(id);
            var borrowerVm = _mapper.Map<NewBorrowerVm>(borrower);
            return borrowerVm;
        }

        public void UpdateBorrower(NewBorrowerVm model)
        {
            var borrower = _mapper.Map<Borrower>(model);
            _borrowerRepo.UpdateBorrower(borrower);
        }
    }
}
