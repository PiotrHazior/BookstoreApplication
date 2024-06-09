using Application.Dto;

namespace BookstoreAdmin.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<bool> CreateCustomerAsync(CustomerDto customer);
        Task<bool> UpdateCustomerAsync(CustomerDto customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
