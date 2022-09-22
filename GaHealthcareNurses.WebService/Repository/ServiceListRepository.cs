using Contracts.RepositoryContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Repository
{
  public class ServiceListRepository : IServiceListRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For ServiceListRepository
        public ServiceListRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<ServiceList>> Get()
        {
            return await _gaHealthcareNursesContext.ServiceList.ToListAsync();
        }

        public async Task<ServiceList> GetById(int id)
        {
            return await _gaHealthcareNursesContext.ServiceList.Where(x => x.ServiceListId == id).FirstOrDefaultAsync();
        }
        #endregion
    }
}
