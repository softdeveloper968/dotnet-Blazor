using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CertificationRepository : ICertificationRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For CertificationRepository
        public CertificationRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(Certification certification)
        {
            await _gaHealthcareNursesContext.Certification.AddAsync(certification);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(Certification certification)
        {
            _gaHealthcareNursesContext.Certification.Remove(certification);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Certification>> Get()
        {
            return await _gaHealthcareNursesContext.Certification.ToListAsync();
        }

        public async Task<Certification> GetById(int id)
        {
            return await _gaHealthcareNursesContext.Certification.Where(x => x.CertificationId == id).FirstOrDefaultAsync();
        }

        public async Task Update(Certification certification)
        {
            _gaHealthcareNursesContext.Certification.Update(certification);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
