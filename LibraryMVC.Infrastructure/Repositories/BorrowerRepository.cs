using LibraryMVC.Domain.Interfaces;
using LibraryMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC.Infrastructure.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly Context _context;
        public BorrowerRepository(Context context)
        {
            _context = context;
        }

        public int AddBorrower(Borrower borrower)
        {
            _context.Borrowers.Add(borrower);
            _context.SaveChanges();
            return borrower.Id;
        }
        public IQueryable<Borrower> GetAllActiveBorrowers()
        {
            return _context.Borrowers.Where(p => p.IsActive);
        }
        public int AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address.Id;
        }
        public Borrower GetBorrower(int borrowerId)
        {
            return _context.Borrowers.Include(x => x.Addresses).Include(x => x.BorrowerContactInformation).FirstOrDefault(p => p.Id == borrowerId);
        }
        public Address GetAddress(int addressId)
        {
            return _context.Addresses.FirstOrDefault(p => p.Id == addressId);
        }
        public void UpdateAddress(Address address)
        {
            _context.Attach(address);
            _context.Entry(address).Property("City").IsModified = true;
            _context.Entry(address).Property("Country").IsModified = true;
            _context.Entry(address).Property("Street").IsModified = true;
            _context.Entry(address).Property("BorrowerId").IsModified = true;
            _context.Entry(address).Property("Email").IsModified = true;
            _context.Entry(address).Property("TelNumber").IsModified = true;
            _context.SaveChanges();

        }
        public void UpdateBorrower(Borrower borrower)
        {
            _context.Attach(borrower);
            _context.Entry(borrower).Property("Name").IsModified = true;
            _context.Entry(borrower).Property("LastName").IsModified = true;
            _context.SaveChanges();
        }
        public void DeleteBorrower(int id)
        {
            var borrower = _context.Borrowers.Find(id);
            if (borrower != null)
            {
                _context.Borrowers.Remove(borrower);
                _context.SaveChanges();
            }
        }
    }
}
