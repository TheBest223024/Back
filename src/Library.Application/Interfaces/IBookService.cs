using Library.Application.DTOs;

namespace Library.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto?> GetBookAsync(int id);
        Task<BookDto> CreateBookAsync(CreateBookDto dto);
        Task<bool> UpdateBookAsync(int id, CreateBookDto dto);
        Task<bool> DeleteBookAsync(int id);
    }
}