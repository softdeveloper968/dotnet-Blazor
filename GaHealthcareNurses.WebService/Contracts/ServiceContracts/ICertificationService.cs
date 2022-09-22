using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ICertificationService
    {
        Task<IEnumerable<Certification>> Get();
        Task<Certification> GetById(int id);
        Task Add(Certification certification);
        Task Delete(Certification certification);
        Task Update(Certification certification);
    }
}
