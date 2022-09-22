using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICertificationRepository
    {
        Task<IEnumerable<Certification>> Get();
        Task<Certification> GetById(int id);
        Task Add(Certification certification);
        Task Update(Certification certification);
        Task Delete(Certification certification);
    }
}
