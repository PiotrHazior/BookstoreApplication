using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders()
        {
            var orders = _mapper.Map<List<OrderDto>>(_orderRepository.GetOrders());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrder(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
                return NotFound();

            var order = _mapper.Map<OrderDto>(_orderRepository.GetOrder(orderId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(order);
        }

        [HttpGet("book/{orderId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(400)]
        public IActionResult GetBookByOrderId(int orderId)
        {
            var books = _mapper.Map<List<BookDto>>(_orderRepository.GetBookByOrder(orderId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromBody] OrderDto orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            var orderMap = _mapper.Map<Order>(orderCreate);

            if (!_orderRepository.CreateOrder(orderMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{orderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOrder(int orderId, [FromBody] OrderDto updatedOrder)
        {
            if (updatedOrder == null)
                return BadRequest(ModelState);

            if (orderId != updatedOrder.Id)
                return BadRequest(ModelState);

            if (!_orderRepository.OrderExists(orderId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var orderMap = _mapper.Map<Order>(updatedOrder);

            if (!_orderRepository.UpdateOrder(orderMap))
            {
                ModelState.AddModelError("", "Something went wrong updating order");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{orderId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOrder(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
            {
                return NotFound();
            }

            var orderToDelete = _orderRepository.GetOrder(orderId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_orderRepository.DeleteOrder(orderToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting order");
            }

            return NoContent();
        }
    }
}
