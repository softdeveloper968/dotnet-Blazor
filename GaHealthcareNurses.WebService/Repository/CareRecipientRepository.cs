using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Contracts.ServiceContracts;

namespace Repository
{
    public class CareRecipientRepository : ICareRecipientRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For CareRecipientRepository
        public CareRecipientRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(CareRecipient careRecipient)
        {
             await _gaHealthcareNursesContext.CareRecipient.AddAsync(careRecipient);
             await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(CareRecipient careRecipient)
        {
            _gaHealthcareNursesContext.CareRecipient.Remove(careRecipient);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CareRecipient>> Get()
        {
            return await _gaHealthcareNursesContext.CareRecipient.Include(x=>x.City).ToListAsync();
        }

        public async Task<CareRecipient> GetById(int id)
        {
            return await _gaHealthcareNursesContext.CareRecipient.Where(x => x.CareRecipientId == id).Include(x=>x.City).FirstOrDefaultAsync();
        }

        public async Task Update(CareRecipient careRecipient)
        {
            _gaHealthcareNursesContext.CareRecipient.Update(careRecipient);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
