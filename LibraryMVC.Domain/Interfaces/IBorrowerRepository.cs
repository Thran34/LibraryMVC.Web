using LibraryMVC.Domain.Model;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IBorrowerRepository
    {
        IQueryable<Borrower> GetAllActiveBorrowers();
        Borrower GetBorrower(int borrowerId);
        Address GetAddress(int addressId);
        int AddBorrower(Borrower borrower);
        public int BorrowBook(Item item);
        int AddAddress(Address address);
        void DeleteBorrower(int id);
        void UpdateBorrower(Borrower borrower);
        void UpdateAddress(Address address);
    }
}
