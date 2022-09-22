using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployerRepository
    {
        Task<int> TotalCount(string filter);
        Task<IEnumerable<Employer>> Get(int skip, int take, string filter);
        Task<IEnumerable<Employer>> GetAll();
        Task<Employer> GetById(string id);
        Task<bool> GetByName(Employer employer);
        Task Add(Employer employer);
        Task<Employer> Update(Employer employer);
        Task Delete(Employer employer);
    }
}
