using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEducationTypeRepository
    {
        Task<IEnumerable<EducationType>> Get();
        Task<EducationType> GetById(int id);
        Task Add(EducationType educationType);
        Task Update(EducationType educationType);
        Task Delete(EducationType educationType);
    }
}
