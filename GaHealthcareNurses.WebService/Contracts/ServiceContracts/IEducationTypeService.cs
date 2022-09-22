using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IEducationTypeService
    {
        Task<IEnumerable<EducationType>> Get();
        Task<EducationType> GetById(int id);
        Task Add(EducationType educationType);
        Task Delete(EducationType educationType);
        Task Update(EducationType educationType);
    }
}
