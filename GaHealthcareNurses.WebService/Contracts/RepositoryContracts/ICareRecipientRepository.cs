using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICareRecipientRepository
    {
        Task<IEnumerable<CareRecipient>> Get();
        Task<CareRecipient> GetById(int id);
        Task Add(CareRecipient careRecipient);
        Task Update(CareRecipient careRecipient);
        Task Delete(CareRecipient careRecipient);
    }
}
