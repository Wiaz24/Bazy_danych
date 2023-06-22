using Microsoft.EntityFrameworkCore;
using Bazy_danych.Models;
using Bazy_danych.Services.Interfaces;

namespace Bazy_danych.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _dbContext;
        public OrderService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.ID_zamowienia;
        }
        public async Task<int> UpdateOrder(Order order)
        {
            _dbContext.Orders.Update(order);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteOrder(int? id)
        {
            if (id == null)
                return 0;

            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null)
                return 0;

            _dbContext.Orders.Remove(order);
            return await _dbContext.SaveChangesAsync();
        }
        public Order GetOrderById(int id)
        {
            return _dbContext.Orders.Find(id);
        }
        public async Task<List<Order>> GetOrdersByUserId(string id)
        {
            return await _dbContext.Orders
                .Where(h => h.ID_uzytkownika == id)
                .ToListAsync();
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }
        
    }
}
