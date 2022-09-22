using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IReferenceService
    {
        Task<IEnumerable<Reference>> Get();
        Task<Reference> GetById(int id);
        Task Add(Reference reference);
        Task Delete(Reference reference);
        Task Update(Reference reference);
    }
}
