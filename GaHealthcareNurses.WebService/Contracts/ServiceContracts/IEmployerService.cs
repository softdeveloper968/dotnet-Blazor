using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IEmployerService
    {
        Task<int> TotalCount(string filter);
        Task<IEnumerable<Employer>> Get(int skip, int take, string filter);
        Task<IEnumerable<Employer>> GetAll();
        Task<Employer> GetById(string id);
        Task<bool> GetByName(Employer employer);
        Task Add(Employer employer);
        Task Delete(Employer employer);
        Task<Employer> Update(EmployerViewModel employer);
    }
}
