using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Contracts.ServiceContracts;

namespace Repository
{
    public class JobApplyRepository : IJobApplyRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;
        private IEducationTypeService _educationTypeService;
        // private readonly IRequiredServiceRepository _requiredServiceRepository;

        #region Contructor For JobApplyRepository
        public JobApplyRepository(GaHealthcareNursesContext context,IEducationTypeService educationTypeService)
        {
            _gaHealthcareNursesContext = context;
            _educationTypeService = educationTypeService;
            //  _requiredServiceRepository = requiredServiceRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<JobApply> Add(JobApply job)
        {
            
            await _gaHealthcareNursesContext.JobApply.AddAsync(job);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return job;
        }


        public async Task Delete(JobApply job)
        {
            _gaHealthcareNursesContext.JobApply.Remove(job);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobApply>> Get()
        {
            return await _gaHealthcareNursesContext.JobApply.Include(x=>x.Status).Include(x=>x.Nurse).Include(x=>x.Job).ToListAsync();
        }

        public async Task<JobApply> GetById(int id)
        {
            var job = await _gaHealthcareNursesContext.JobApply.Where(x => x.Id == id).Include(x=>x.Job.Employer).Include(x=>x.Status).Include(x=>x.Job).Include(x=>x.Job.JobTitle).Include(x=>x.Nurse).FirstOrDefaultAsync();
            return job;
        }

        public async Task<IEnumerable<JobApply>> GetByJobId(int id)
        {
            var jobs = await _gaHealthcareNursesContext.JobApply.Where(x => x.JobId == id).Include(x => x.Status).Include(x => x.Job).Include(x=>x.Nurse).Include(x=>x.Nurse.WorkExperiences).Include(x=>x.Nurse.Educations).Include(x=>x.Nurse.Certifications).Include(x=>x.Nurse.City).Include(x=>x.Nurse.References).ToListAsync();
            return jobs;
        }

        public async Task<IEnumerable<JobApply>> GetByStatusId(string nurseId,int statusId)
        {
            var jobs = await _gaHealthcareNursesContext.JobApply.Where(x => x.NurseId == nurseId && x.StatusId==statusId).Include(x => x.Status).Include(x => x.Job).Include(x=>x.Job.CareRecipient).Include(x=>x.Job.CareRecipient.City).Include(x=>x.Job.CareRecipient.State).Include(x=>x.Job.CareRecipient.ServiceList).Include(x => x.Nurse).Include(x=>x.Job.Client).Include(x=>x.Job.JobTitle).ToListAsync();
            return jobs;
        }

        public async Task<IEnumerable<JobApply>> GetByJobIdAndStatusId(int jobId, int statusId)
        {
            var jobs = await _gaHealthcareNursesContext.JobApply.Where(x => x.JobId == jobId && x.StatusId == statusId).Include(x => x.Status).Include(x => x.Job).Include(x => x.Job.CareRecipient).Include(x => x.Job.CareRecipient.City).Include(x => x.Job.CareRecipient.State).Include(x => x.Job.CareRecipient.ServiceList).Include(x => x.Nurse).Include(x => x.Nurse.WorkExperiences).Include(x => x.Nurse.Educations).Include(x => x.Nurse.Certifications).Include(x => x.Nurse.City).Include(x => x.Nurse.References).Include(x => x.Job.Client).Include(x => x.Job.JobTitle).ToListAsync();
          
            foreach(var job in jobs)
            {
                foreach (var educationType in job.Nurse.Educations)
                {
                    EducationType education = new EducationType();
                    education = await _educationTypeService.GetById((int)educationType.EducationTypeId);
                    educationType.EducationType = education;
                }
            }
            return jobs;
        }


        public async Task<IEnumerable<JobApply>> GetByNurseId(string id)
        {
            var jobs = await _gaHealthcareNursesContext.JobApply.Where(x => x.NurseId == id).Include(x => x.Status).Include(x => x.Job.CareRecipient).Include(x=>x.Nurse).ToListAsync();
            return jobs;
        }

        public async Task<JobApply> Update(JobApply job)
        {
            _gaHealthcareNursesContext.JobApply.Update(job);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return job;
        }
        #endregion
    }
}
