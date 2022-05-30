using LibraryMVC.Domain.Model;

namespace LibraryMVC.Application.Interfaces
{
    public interface IUserService
    {
        public Item? SelectBook(int userId);
        public Borrower GetBorrower(int id);

    }
}
