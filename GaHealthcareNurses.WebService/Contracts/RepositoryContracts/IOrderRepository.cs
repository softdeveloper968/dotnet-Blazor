using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> GetById(string id);
        Task<IEnumerable<Order>> GetByEmployerId(string id);
        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task Delete(Order order);
        Task<IEnumerable<Order>> GetActiveOrderByEmployerId(string id);
    }
}
