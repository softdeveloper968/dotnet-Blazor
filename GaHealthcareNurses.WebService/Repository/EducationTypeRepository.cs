using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EducationTypeRepository : IEducationTypeRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public EducationTypeRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(EducationType educationType)
        {
            await _gaHealthcareNursesContext.EducationType.AddAsync(educationType);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(EducationType educationType)
        {
            _gaHealthcareNursesContext.EducationType.Remove(educationType);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EducationType>> Get()
        {
            return await _gaHealthcareNursesContext.EducationType.ToListAsync();
        }

        public async Task<EducationType> GetById(int id)
        {
            return await _gaHealthcareNursesContext.EducationType.Where(x => x.EducationTypeId == id).FirstOrDefaultAsync();
        }

        public async Task Update(EducationType educationType)
        {
            _gaHealthcareNursesContext.EducationType.Update(educationType);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
