using Bazy_danych.Models;

namespace Bazy_danych.Services.Interfaces
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
