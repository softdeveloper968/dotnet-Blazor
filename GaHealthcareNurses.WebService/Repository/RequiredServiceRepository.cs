using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Contracts.RepositoryContracts;

namespace Repository
{
    public class RequiredServiceRepository : IRequiredServiceRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For RequiredServiceRepository
        public RequiredServiceRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface

        public async Task Add(RequiredService requiredService)
        {
            await _gaHealthcareNursesContext.RequiredService.AddAsync(requiredService);

            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        public async Task Update(RequiredService requiredService)
        {
            _gaHealthcareNursesContext.RequiredService.Update(requiredService);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RequiredService>> Get()
        {
            return await _gaHealthcareNursesContext.RequiredService.ToListAsync();
        }

        public async Task<RequiredService> GetById(int id)
        {
            return await _gaHealthcareNursesContext.RequiredService.Where(x => x.RequiredServiceId == id).Include(x => x.CareRecipients).FirstOrDefaultAsync();
        }
        public async Task Delete(RequiredService requiredService)
        {
            _gaHealthcareNursesContext.RequiredService.Remove(requiredService);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
