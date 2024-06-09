using Domain.Entities;
using System.ServiceModel;

namespace BookstoreSoapService.Interfaces
{
    [ServiceContract]
    public interface ICustomerSoapService
    {
        [OperationContract]
        Task<ICollection<Customer>> GetCustomersAsync();

        [OperationContract]
        Task<Customer> GetCustomerAsync(int id);

        [OperationContract]
        Task<bool> CustomerExistsAsync(int customerId);

        [OperationContract]
        Task<bool> CreateCustomerAsync(Customer customer);

        [OperationContract]
        Task<bool> UpdateCustomerAsync(Customer customer);

        [OperationContract]
        Task<bool> DeleteCustomerAsync(int customerId);

        [OperationContract]
        Task<bool> SaveAsync();
    }
}
