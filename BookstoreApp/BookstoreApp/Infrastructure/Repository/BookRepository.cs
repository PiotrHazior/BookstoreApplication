using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            this._context = context;
        }

        public bool BookExists(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }

        public bool CreateBook(Book book)
        {
            _context.Books.Add(book);
            return Save();
        }

        public bool UpdateBook(Book book)
        {
            _context.Books.Update(book);
            return Save();
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        public Book GetBook(string title)
        {
            return _context.Books.Where(b => b.Title == title).FirstOrDefault();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(b => b.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }
    }
}
