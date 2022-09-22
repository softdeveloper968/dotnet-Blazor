using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IAgencyTaskListService
    {
        Task<IEnumerable<AgencyTaskList>> Get();
        Task<AgencyTaskList> GetById(int id);
        Task<AgencyTaskList> Add(AgencyTaskList taskList);
        Task<AgencyTaskList> Update(AgencyTaskList taskList);
        Task Delete(AgencyTaskList taskList);
        Task AddTaskListTemplates(List<AgencyTaskListViewModel> agencyTaskList);
    }
}
