using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using GaHealthcareNurses.Entity.ViewModels;

namespace Repository
{
    public class JobRepository : IJobRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;
        // private readonly IRequiredServiceRepository _requiredServiceRepository;

        #region Contructor For JobRepository
        public JobRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
            //  _requiredServiceRepository = requiredServiceRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<Job> Add(Job job)
        {
            await _gaHealthcareNursesContext.Job.AddAsync(job);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return job;
        }

        public async Task<int> TotalCount(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            return await _gaHealthcareNursesContext.Job.CountAsync();

            return await _gaHealthcareNursesContext.Job.Where(x => x.Description.Contains(filter) || x.CareRecipient.City.Name.Contains(filter) || x.JobTitle.Title.Contains(filter) || x.PostedTime.ToString().Contains(filter)).CountAsync();
        }

        public async Task Delete(Job job)
        {
            _gaHealthcareNursesContext.Job.Remove(job);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Job>> Get(PaginationFilter paginationFilter)
        {
            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await _gaHealthcareNursesContext.Job.Where(x=>x.SentToNurse==true).Include(x => x.CareRecipient).Include(x => x.CareRecipient.City).Include(x => x.Resource).Include(x=>x.JobTitle).Include(x => x.Employer).Include(x => x.VisitNotes).Include(x=>x.Status).OrderByDescending(x=>x.JobId).Skip(skip).Take(paginationFilter.PageSize).Include(x=>x.JobApplies).ToListAsync();

        }

        public async Task<IEnumerable<Job>> GetJobsForAgency(int skip,int take,string filter)
        {
            if(filter!=null)
            {
                var filteredRecords = await _gaHealthcareNursesContext.Job.Where(x => x.Description.Contains(filter) || x.CareRecipient.City.Name.Contains(filter) || x.JobTitle.Title.Contains(filter) || x.PostedTime.ToString().Contains(filter)).Include(x => x.CareRecipient).Include(x => x.CareRecipient.City).Include(x => x.Resource).Include(x => x.JobTitle).Include(x => x.Employer).Include(x => x.VisitNotes).Include(x => x.Status).OrderByDescending(x => x.JobId).ToListAsync();
                return filteredRecords.Skip(skip).Take(take).ToList();
            }
            return await _gaHealthcareNursesContext.Job.Include(x => x.CareRecipient).Include(x => x.CareRecipient.City).Include(x => x.Resource).Include(x => x.JobTitle).Include(x => x.Employer).Include(x => x.VisitNotes).Include(x => x.Status).OrderByDescending(x => x.JobId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Job> GetById(int id)
        {
            var job = await _gaHealthcareNursesContext.Job.Where(x => x.JobId == id).Include(x => x.Resource).Include(x=>x.JobTitle).Include(x => x.Employer).Include(x => x.VisitNotes).Include(x => x.CareRecipient).Include(x => x.CareRecipient.City).FirstOrDefaultAsync();
            return job;
        }

        public async Task<IEnumerable<Job>> GetByClientId(string id)
        {
           return await _gaHealthcareNursesContext.Job.Where(x => x.ClientId == id).Include(x => x.Resource).Include(x=>x.JobTitle).Include(x => x.Employer).Include(x => x.VisitNotes).Include(x => x.CareRecipient).Include(x => x.CareRecipient.City).ToListAsync();   
        }
        public async Task Update(Job job)
        {
            _gaHealthcareNursesContext.Job.Update(job);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
