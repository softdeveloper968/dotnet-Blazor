using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> GetById(string id);
        Task<Order> Add(Order order);
        Task<Order> Update(Order order);
        Task Delete(Order order);
        Task<Order> AddSubscription(AddSubscriptionViewModel addSubscriptionViewModel);
        Task<IEnumerable<Order>> GetByEmployerId(string id);
        Task UpdateSubscription(UpdateSubscriptionViewModel updateSubscriptionViewModel);
        Task<IEnumerable<Order>> GetActiveOrder(string id);
    }
}
