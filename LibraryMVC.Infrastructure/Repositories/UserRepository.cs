using LibraryMVC.Domain.Interfaces;

namespace LibraryMVC.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context = context;
        }
        public void BorrowBook(int id)
        {
        }
    }
}
