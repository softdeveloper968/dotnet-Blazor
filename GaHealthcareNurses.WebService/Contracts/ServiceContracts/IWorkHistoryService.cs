using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IWorkHistoryService
    {
        Task<List<WorkHistoryResponseModel>> GetWorkHistory(WorkHistoryViewModel workHistory);
        Task<IEnumerable<NurseWorkHistoryViewModel>> GetWorkHistoryForNurse(string id);
    }
}
