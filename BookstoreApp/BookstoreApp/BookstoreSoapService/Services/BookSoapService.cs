using BookstoreSoapService.Interfaces;
using Domain.Entities;

namespace BookstoreSoapService.Services
{
    public class BookSoapService : IBookSoapService
    {
        private readonly List<Book> _books = new List<Book>();

        public Task<bool> BookExistsAsync(int bookId)
        {
            return Task.FromResult(_books.Any(b => b.Id == bookId));
        }

        public Task<bool> CreateBookAsync(int orderId, Book book)
        {
            _books.Add(book);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteBookAsync(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null)
            {
                _books.Remove(book);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Book> GetBookAsync(int id)
        {
            return Task.FromResult(_books.FirstOrDefault(b => b.Id == id));
        }

        public Task<Book> GetBookByTitleAsync(string title)
        {
            return Task.FromResult(_books.FirstOrDefault(b => b.Title == title));
        }

        public Task<ICollection<Book>> GetBooksAsync()
        {
            return Task.FromResult((ICollection<Book>)_books);
        }

        public Task<bool> SaveAsync()
        {
            return Task.FromResult(true);
        }

        public Task<bool> UpdateBookAsync(int orderId, Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

    }
}
