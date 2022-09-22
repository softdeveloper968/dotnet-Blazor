using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private ISubscriptionRepository _subscriptionRepository;

        #region Constructor for SubscriptionService
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Subscription>> Get()
        {
            return await _subscriptionRepository.Get();
        }

        public async Task<Subscription> GetById(int id)
        {
            return await _subscriptionRepository.GetById(id);
        }

        public async Task<Subscription> Add(Subscription subscription)
        {
           return await _subscriptionRepository.Add(subscription);
        }

        public async Task Delete(Subscription subscription)
        {
            await _subscriptionRepository.Delete(subscription);
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
           return await _subscriptionRepository.Update(subscription);
        }
        #endregion
    }
}
