using Library.Domain.Entities;
using Library.Domain.Ports.Out;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Loan>> GetActiveLoansAsync() =>
            await _context.Loans
                .Where(l => l.Status == "Active")
                .Include(l => l.Book)
                .ToListAsync();
    }
}