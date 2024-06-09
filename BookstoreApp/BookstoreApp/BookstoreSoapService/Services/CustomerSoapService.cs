using BookstoreSoapService.Interfaces;
using Domain.Entities;

namespace BookstoreSoapService.Services
{
    public class CustomerSoapService : ICustomerSoapService
    {
        private readonly List<Customer> _customers = new List<Customer>();
        public Task<bool> CreateCustomerAsync(Customer customer)
        {
            _customers.Add(customer);
            return Task.FromResult(true);
        }

        public Task<bool> CustomerExistsAsync(int customerId)
        {
            return Task.FromResult(_customers.Any(c => c.Id == customerId));
        }

        public Task<bool> DeleteCustomerAsync(int customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                _customers.Remove(customer);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            return Task.FromResult(_customers.FirstOrDefault(c => c.Id == id));
        }

        public Task<ICollection<Customer>> GetCustomersAsync()
        {
            return Task.FromResult((ICollection<Customer>) _customers);
        }

        public Task<bool> SaveAsync()
        {
            return Task.FromResult(true);
        }

        public Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.LastName = customer.LastName;
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
