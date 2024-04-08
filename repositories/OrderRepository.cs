using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using rentacar.data;
using rentacar.interfaces;
using rentacar.models;

namespace rentacar.repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _context;

        public OrderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Order> createOrder(Order order)
        {   
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Task<Order?> deleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Order?> getOrderById(int id)
        {
            return await _context.Orders.Include(c => c.car).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Order>> getOrdersForUser(int userId)
        {
           return await _context.Orders.Include(c => c.car).Where(x => x.userId == userId).ToListAsync();
        }

        public Task<Order?> updateOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}