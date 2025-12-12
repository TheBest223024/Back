using Library.Domain.Entities;
using Library.Domain.Ports.Out;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Book?> GetByISBNAsync(string isbn) =>
            await _context.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
    }
}