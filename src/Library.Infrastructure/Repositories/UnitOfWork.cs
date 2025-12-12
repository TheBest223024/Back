using Library.Domain.Ports.Out;
using Library.Infrastructure;

namespace Library.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBookRepository Books { get; }
        public ILoanRepository Loans { get; }

        public UnitOfWork(ApplicationDbContext context, IBookRepository books, ILoanRepository loans)
        {
            _context = context;
            Books = books;
            Loans = loans;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}