using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;

namespace BookstoreAdmin.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, DataContext context)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateCustomerAsync(CustomerDto customerDto)
        {
            var customerEntity = _mapper.Map<Customer>(customerDto);
            var result = _customerRepository.CreateCustomer(customerEntity);
            return result;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            var result = _customerRepository.DeleteCustomer(customer);
            return result;
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var customer = _customerRepository.GetCustomer(id);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            var customers = _customerRepository.GetCustomers();
            var customersDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return customersDto;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerDto customer)
        {
            var customerEntity = _mapper.Map<Customer>(customer);
            var result = _customerRepository.UpdateCustomer(customerEntity);
            return result;
        }
    }
}
