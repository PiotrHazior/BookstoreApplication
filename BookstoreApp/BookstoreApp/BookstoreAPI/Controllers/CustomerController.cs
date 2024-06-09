using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult GetCustomers()
        {
            var customers = _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(int id)
        {
            if (!_customerRepository.CustomerExists(id))
                return NotFound();

            var customer = _mapper.Map<CustomerDto>(_customerRepository.GetCustomer(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerCreate)
        {
            if (customerCreate == null)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(customerCreate);

            if (!_customerRepository.CreateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto updatedCustomer)
        {
            if (updatedCustomer == null)
                return BadRequest(ModelState);

            if (id != updatedCustomer.Id)
                return BadRequest(ModelState);

            if (!_customerRepository.CustomerExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customerMap = _mapper.Map<Customer>(updatedCustomer);

            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating customer");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCustomer(int id)
        {
            if (!_customerRepository.CustomerExists(id))
            {
                return NotFound();
            }

            var customerToDelete = _customerRepository.GetCustomer(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_customerRepository.DeleteCustomer(customerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting customer");
            }

            return NoContent();
        }
    }
}
