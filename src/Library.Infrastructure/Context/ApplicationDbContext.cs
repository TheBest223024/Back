using Microsoft.EntityFrameworkCore;
using Library.Domain.Entities;

namespace Library.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}