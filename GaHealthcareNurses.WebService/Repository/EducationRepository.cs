using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EducationRepository : IEducationRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public EducationRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(Education education)
        {
            await _gaHealthcareNursesContext.Education.AddAsync(education);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(Education education)
        {
            _gaHealthcareNursesContext.Education.Remove(education);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Education>> Get()
        {
            return await _gaHealthcareNursesContext.Education.ToListAsync();
        }

        public async Task<Education> GetById(int id)
        {
            return await _gaHealthcareNursesContext.Education.Where(x => x.EducationId == id).FirstOrDefaultAsync();
        }

        public async Task Update(Education education)
        {
            _gaHealthcareNursesContext.Education.Update(education);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
