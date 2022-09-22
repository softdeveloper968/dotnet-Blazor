using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For SubscriptionRepository
        public SubscriptionRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<Subscription> Add(Subscription subscription)
        {
            await _gaHealthcareNursesContext.Subscription.AddAsync(subscription);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return subscription;
        }

        public async Task Delete(Subscription subscription)
        {
            _gaHealthcareNursesContext.Subscription.Remove(subscription);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscription>> Get()
        {
            return await _gaHealthcareNursesContext.Subscription.ToListAsync();
        }

        public async Task<Subscription> GetById(int id)
        {
            return await _gaHealthcareNursesContext.Subscription.Where(x => x.SubscriptionId == id).FirstOrDefaultAsync();
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            _gaHealthcareNursesContext.Subscription.Update(subscription);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return subscription;
        }
        #endregion
    }
}
