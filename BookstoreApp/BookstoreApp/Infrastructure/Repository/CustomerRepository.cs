using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            return Save();
        }

        public bool CustomerExists(int id)
        {
            return _context.Customers.Any(c => c.Id == id);
        }

        public bool DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(c => c.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            return Save();
        }
    }
}
