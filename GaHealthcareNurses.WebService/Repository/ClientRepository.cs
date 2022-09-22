using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClientRepository : IClientRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For ClientRepository
        public ClientRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task Add(Client client)
        {
            await _gaHealthcareNursesContext.Client.AddAsync(client);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            _gaHealthcareNursesContext.Client.Remove(client);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> Get()
        {
            return await _gaHealthcareNursesContext.Client.Include(x=>x.CareRecipients).ToListAsync();
        }

        public async Task<Client> GetById(string id)
        {
            return await _gaHealthcareNursesContext.Client.Where(x => x.Id == id).Include(x=>x.CareRecipients).FirstOrDefaultAsync();
        }

        public async Task Update(Client client)
        {
            _gaHealthcareNursesContext.Client.Update(client);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        #endregion
    }
}
