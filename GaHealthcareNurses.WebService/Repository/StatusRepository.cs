using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StatusRepository : IStatusRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;
        // private readonly IRequiredServiceRepository _requiredServiceRepository;

        #region Contructor For StatusRepository
        public StatusRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
            //  _requiredServiceRepository = requiredServiceRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<Status> Add(Status status)
        {
            await _gaHealthcareNursesContext.Status.AddAsync(status);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return status;
        }


        public async Task Delete(Status status)
        {
            _gaHealthcareNursesContext.Status.Remove(status);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Status>> Get()
        {
            return await _gaHealthcareNursesContext.Status.ToListAsync();
        }

        public async Task<IEnumerable<Status>> GetByTypeId(int id)
        {
            return await _gaHealthcareNursesContext.Status.Where(x=>x.TypeId==id).ToListAsync();
        }
        public async Task<Status> GetById(int id)
        {
            var status = await _gaHealthcareNursesContext.Status.Where(x => x.StatusId == id).FirstOrDefaultAsync();
            return status;
        }
        public async Task Update(Status status)
        {
            _gaHealthcareNursesContext.Status.Update(status);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
