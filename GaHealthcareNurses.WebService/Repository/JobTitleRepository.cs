using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class JobTitleRepository : IJobTitleRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;
        // private readonly IRequiredServiceRepository _requiredServiceRepository;

        #region Contructor For JobTitleRepository
        public JobTitleRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
            //  _requiredServiceRepository = requiredServiceRepository;
        }
        #endregion

        #region Implementing Interface
     
        public async Task<IEnumerable<JobTitle>> Get( )
        {
            return await _gaHealthcareNursesContext.JobTitle.ToListAsync();
        }

        public async Task<JobTitle> Add(JobTitle jobTitle)
        {
            await _gaHealthcareNursesContext.JobTitle.AddAsync(jobTitle);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return jobTitle;
        }
        public async Task<JobTitle> GetById(int id)
        {
            var job = await _gaHealthcareNursesContext.JobTitle.Where(x => x.JobTitleId == id).FirstOrDefaultAsync();
            return job;
        }
        #endregion
    }
}
