using Microsoft.EntityFrameworkCore;
using Library.Domain.Ports.Out;
using Library.Infrastructure; 

namespace Library.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<T?> GetByIdAsync(int id) =>
            await _context.Set<T>().FindAsync(id);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}