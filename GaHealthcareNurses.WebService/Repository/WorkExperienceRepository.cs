using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public WorkExperienceRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(WorkExperience workExperience)
        {
            await _gaHealthcareNursesContext.WorkExperience.AddAsync(workExperience);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(WorkExperience workExperience)
        {
            _gaHealthcareNursesContext.WorkExperience.Remove(workExperience);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkExperience>> Get()
        {
            return await _gaHealthcareNursesContext.WorkExperience.ToListAsync();
        }

        public async Task<WorkExperience> GetById(int id)
        {
            return await _gaHealthcareNursesContext.WorkExperience.Where(x => x.WorkExperienceId == id).FirstOrDefaultAsync();
        }

        public async Task Update(WorkExperience workExperience)
        {
            _gaHealthcareNursesContext.WorkExperience.Update(workExperience);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
