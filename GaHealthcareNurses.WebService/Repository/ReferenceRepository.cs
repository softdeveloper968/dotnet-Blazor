using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ReferenceRepository : IReferenceRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public ReferenceRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(Reference reference)
        {
            await _gaHealthcareNursesContext.Reference.AddAsync(reference);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(Reference reference)
        {
            _gaHealthcareNursesContext.Reference.Remove(reference);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reference>> Get()
        {
            return await _gaHealthcareNursesContext.Reference.ToListAsync();
        }

        public async Task<Reference> GetById(int id)
        {
            return await _gaHealthcareNursesContext.Reference.Where(x => x.ReferenceId == id).FirstOrDefaultAsync();
        }

        public async Task Update(Reference reference)
        {
            _gaHealthcareNursesContext.Reference.Update(reference);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
