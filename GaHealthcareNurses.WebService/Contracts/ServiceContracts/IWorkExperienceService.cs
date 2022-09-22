using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IWorkExperienceService
    {
        Task<IEnumerable<WorkExperience>> Get();
        Task<WorkExperience> GetById(int id);
        Task Add(WorkExperience workExperience);
        Task Delete(WorkExperience workExperience);
        Task Update(WorkExperience workExperience);
    }
}
