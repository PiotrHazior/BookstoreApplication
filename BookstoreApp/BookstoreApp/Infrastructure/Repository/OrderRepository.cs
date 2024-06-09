using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.Id == id);
        }

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.Id).ToList();
        }

        public Order GetOrder(int id)
        {
            return _context.Orders.Where(o => o.Id == id).FirstOrDefault();
        }

        public ICollection<Book> GetBookByOrder(int orderId)
        {
            return _context.OrderBooks.Where(o => o.OrderId == orderId).Select(o => o.Book).ToList();
        }

        public bool CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateOrder(Order order)
        {
            _context.Update(order);
            return Save();
        }

        public bool DeleteOrder(Order order)
        {
            _context.Remove(order);
            return Save();
        }
    }
}
