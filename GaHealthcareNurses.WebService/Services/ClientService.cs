using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientService : IClientService
    {
        private IClientRepository _clientRepository;

        #region Constructor for EmployerService
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Client>> Get()
        {
            return await _clientRepository.Get();
        }

        public async Task<Client> GetById(string id)
        {
            return await _clientRepository.GetById(id);
        }

        public async Task Add(Client client)
        {
            await _clientRepository.Add(client);
        }

        public async Task Delete(Client client)
        {
            await _clientRepository.Delete(client);
        }

        public async Task Update(Client client)
        {
            await _clientRepository.Update(client);
        }
        #endregion
    }
}
