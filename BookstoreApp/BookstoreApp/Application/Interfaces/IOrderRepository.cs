using Domain.Entities;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrder(int id);
        ICollection<Book> GetBookByOrder(int orderId);
        bool OrderExists(int id);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(Order order);
        bool Save();
    }
}
