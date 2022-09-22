using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IReferenceRepository
    {
        Task<IEnumerable<Reference>> Get();
        Task<Reference> GetById(int id);
        Task Add(Reference reference);
        Task Update(Reference reference);
        Task Delete(Reference reference);
    }
}
