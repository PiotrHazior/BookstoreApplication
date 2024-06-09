using Domain.Entities;
using System.ServiceModel;

namespace BookstoreSoapService.Interfaces
{
    [ServiceContract]
    public interface IBookSoapService
    {
        [OperationContract]
        Task<ICollection<Book>> GetBooksAsync();

        [OperationContract]
        Task<Book> GetBookAsync(int id);

        [OperationContract]
        Task<Book> GetBookByTitleAsync(string title);

        [OperationContract]
        Task<bool> BookExistsAsync(int bookId);

        [OperationContract]
        Task<bool> CreateBookAsync(int orderId, Book book);

        [OperationContract]
        Task<bool> UpdateBookAsync(int orderId, Book book);

        [OperationContract]
        Task<bool> DeleteBookAsync(int bookId);

        [OperationContract]
        Task<bool> SaveAsync();

    }
}
