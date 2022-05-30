using LibraryMVC.Application.Interfaces;
using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Model;

namespace LibraryMVC.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IItemRepository _itemRepo;
        private readonly IUserRepository _userRepository;
        private readonly IBorrowerRepository _borrowerRepository;
        public UserService(IItemRepository itemRepo, IUserRepository userRepository, IBorrowerRepository borrowerRepository)
        {
            _itemRepo = itemRepo;
            _userRepository = userRepository;
            _borrowerRepository = borrowerRepository;
        }
        public Item? SelectBook(int userId)
        {
            var book = _itemRepo.GetItem(userId);
            book.BorrowerId = userId;
            return book;
        }
        public Borrower GetBorrower(int id)
        {
            var borrower = _borrowerRepository.GetBorrower(id);
            return borrower;
        }
    }
}
