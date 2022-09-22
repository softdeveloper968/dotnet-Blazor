using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEducationRepository
    {
        Task<IEnumerable<Education>> Get();
        Task<Education> GetById(int id);
        Task Add(Education education);
        Task Update(Education education);
        Task Delete(Education education);
    }
}
