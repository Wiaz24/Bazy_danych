using Platformy_Programowania_1.Models;

namespace Platformy_Programowania_1.Services.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrder(Order order);
        Task<int> UpdateOrder(Order order);
        Task<int> DeleteOrder(int? id);
        Order GetOrderById(int id);
        Task<IEnumerable<Order>> GetOrders();
        Task<List<Order>> GetOrdersByUserId(string id);
    }
}
