using LibraryMVC.Domain.Model;

namespace LibraryMVC.Domain.Interfaces
{
    public interface IBorrowerRepository
    {
        IQueryable<Borrower> GetAllActiveBorrowers();
        Borrower GetBorrower(int borrowerId);

        int AddBorrower(Borrower borrower);

        void DeleteBorrower(int id);
        void UpdateBorrower(Borrower borrower);
    }
}
