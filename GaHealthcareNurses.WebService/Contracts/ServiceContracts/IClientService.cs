using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> GetById(string id);
        Task Add(Client client);
        Task Delete(Client client);
        Task Update(Client client);
    }
}
