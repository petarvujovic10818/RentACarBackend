using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rentacar.models;

namespace rentacar.interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> getOrdersForUser(int userId);
        Task<Order?> getOrderById(int id);
        Task<Order> createOrder(Order order);
        Task<Order?> updateOrder(int id); //ADD DTO
        Task<Order?> deleteOrder(int id);
    }
}