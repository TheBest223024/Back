using AutoMapper;
using Library.Application.DTOs;
using Library.Domain.Entities;
using Library.Domain.Ports.Out;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            var existing = await _uow.Books.GetByISBNAsync(dto.ISBN);
            if (existing != null)
                throw new Exception("ISBN ya registrado");

            var book = _mapper.Map<Book>(dto);
            book.CreatedAt = DateTime.Now;

            await _uow.Books.AddAsync(book);
            await _uow.SaveChangesAsync();

            return _mapper.Map<BookDto>(book);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _uow.Books.GetByIdAsync(id);
            if (book == null) return false;

            _uow.Books.Delete(book);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<BookDto?> GetBookAsync(int id)
        {
            var book = await _uow.Books.GetByIdAsync(id);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _uow.Books.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<bool> UpdateBookAsync(int id, CreateBookDto dto)
        {
            var book = await _uow.Books.GetByIdAsync(id);
            if (book == null) return false;

            _mapper.Map(dto, book);
            _uow.Books.Update(book);
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}