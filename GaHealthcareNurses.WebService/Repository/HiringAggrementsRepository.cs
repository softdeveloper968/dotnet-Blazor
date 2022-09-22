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
    public class HiringAggrementsRepository : IHiringAggrementsRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For HiringAggrementsRepository
        public HiringAggrementsRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface

        public async Task AddHiringAggrement(HiringAgreements hiringAgreements)
        {
            await _gaHealthcareNursesContext.HiringAgreements.AddAsync(hiringAgreements);

            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        public async Task UpdateHiringAggrement(HiringAgreements hiringAgreements)
        {
            _gaHealthcareNursesContext.HiringAgreements.Update(hiringAgreements);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HiringAgreements>> Get()
        {
            return await _gaHealthcareNursesContext.HiringAgreements.ToListAsync();
        }

        public async Task<HiringAgreements> GetById(string id)
        {
            return await _gaHealthcareNursesContext.HiringAgreements.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        #endregion
    }
}
