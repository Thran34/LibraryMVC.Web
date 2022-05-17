using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryMVC.Application.Interfaces;
using LibraryMVC.Application.ViewModel.Borrower;
using LibraryMVC.Application.ViewModel.Item;
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
            borrowerVm.ParentFullName = borrower.ParentName + " " + borrower.ParentLastName;
            borrowerVm.Addresses = new List<AddressForListVm>();
            borrowerVm.Books = new List<ItemForListVm>();
            foreach (var address in borrower.Addresses)
            {
                var add = new AddressForListVm()
                {
                    City = address.City,
                    Country = address.Country,
                    Street = address.Street,
                    TelNumber = address.TelNumber,
                    Email = address.Email,

                };
                borrowerVm.Addresses.Add(add);
            }
            foreach (var item in borrower.Books)
            {
                var book = new ItemForListVm()
                {
                    Genre = item.Genre,
                    Name = item.Name,
                    AuthorName = item.AuthorName,
                    AuthorLastName = item.AuthorLastName,
                };
                borrowerVm.Books.Add(book);
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
        public int AddAddress(NewAddresVm address)
        {
            var addr = _mapper.Map<Address>(address);
            var id = _borrowerRepo.AddAddress(addr);
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
        public NewAddresVm GetAddressForEdit(int id)
        {

            var address = _borrowerRepo.GetAddress(id);
            var addressVm = _mapper.Map<NewAddresVm>(address);
            return addressVm;
        }
        public void UpdateAddress(NewAddresVm model)
        {
            var address = _mapper.Map<Address>(model);
            _borrowerRepo.UpdateAddress(address);
        }
        public void BorrowBook()
        {

        }
    }
}
