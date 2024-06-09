using Application.Dto;

namespace BookstoreAdmin.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookAsync(int id);
        Task<bool> CreateBookAsync(BookDto book);
        Task<bool> UpdateBookAsync(BookDto book);
        Task<bool> DeleteBookAsync(int id);
    }
}
