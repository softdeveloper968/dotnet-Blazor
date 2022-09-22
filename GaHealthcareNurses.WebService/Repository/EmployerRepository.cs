using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class EmployerRepository : IEmployerRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public EmployerRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(Employer employer)
        {
            await _gaHealthcareNursesContext.Employer.AddAsync(employer);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<int> TotalCount(string filter)
        {
            if(string.IsNullOrEmpty(filter))
            return await _gaHealthcareNursesContext.Employer.CountAsync();
            return await _gaHealthcareNursesContext.Employer.Where(x => x.Name.Contains(filter) || x.EmailAddress.Contains(filter) || x.TelephoneNo.Contains(filter) || x.City.Name.Contains(filter)).CountAsync();
        
        }
        public async Task Delete(Employer employer)
        {
            _gaHealthcareNursesContext.Employer.Remove(employer);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employer>> Get(int skip, int take, string filter)
        {
            if (filter != null)
            {
                var filteredRecords = await _gaHealthcareNursesContext.Employer.Where(x => x.Name.Contains(filter) || x.EmailAddress.Contains(filter) || x.TelephoneNo.Contains(filter) || x.City.Name.Contains(filter)).Include(x=>x.City).Include(x=>x.State).OrderByDescending(x => x.Id).ToListAsync();
                return filteredRecords.Skip(skip).Take(take).ToList();
            }
            return await _gaHealthcareNursesContext.Employer.Include(x=>x.City).Include(x=>x.State).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<Employer>> GetAll()
        {
            return await _gaHealthcareNursesContext.Employer.ToListAsync();
        }

        public async Task<Employer> GetById(string id)
        {
            return await _gaHealthcareNursesContext.Employer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<bool> GetByName(Employer employer)
        {
            var employerData =  _gaHealthcareNursesContext.Employer.Where(x => x.Name == employer.Name).FirstOrDefault();
            if (employerData != null)
                return true;
            return false;
        }
        public async Task<Employer> Update(Employer employer)
        {
            _gaHealthcareNursesContext.Employer.Update(employer);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return employer;
        }
        #endregion
    }
}
