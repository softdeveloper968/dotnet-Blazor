using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IWorkExperienceRepository
    {
        Task<IEnumerable<WorkExperience>> Get();
        Task<WorkExperience> GetById(int id);
        Task Add(WorkExperience workExperience);
        Task Update(WorkExperience workExperience);
        Task Delete(WorkExperience workExperience);
    }
}
