using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> Get();
        Task<Subscription> GetById(int id);
        Task<Subscription> Add(Subscription subscription);
        Task<Subscription> Update(Subscription subscription);
        Task Delete(Subscription subscription);
    }
}
