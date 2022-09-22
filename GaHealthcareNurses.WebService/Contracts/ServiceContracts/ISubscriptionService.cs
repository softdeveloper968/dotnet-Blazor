using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<Subscription>> Get();
        Task<Subscription> GetById(int id);
        Task<Subscription> Add(Subscription subscription);
        Task<Subscription> Update(Subscription subscription);
        Task Delete(Subscription subscription);
    }
}
