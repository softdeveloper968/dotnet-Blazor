using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ICareRecipientService
    {
        Task<IEnumerable<CareRecipient>> Get();
        Task<CareRecipient> GetById(int id);
        Task Add(CareRecipient careRecipient);
        Task Delete(CareRecipient careRecipient);
        Task Update(CareRecipient careRecipient);
    }
}
