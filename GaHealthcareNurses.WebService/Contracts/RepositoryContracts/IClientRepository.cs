using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> Get();
        Task<Client> GetById(string id);
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(Client client);
    }
}
