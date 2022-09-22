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
  public class StateRepository:IStateRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public StateRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<State>> Get()
        {
            return await _gaHealthcareNursesContext.State.ToListAsync();
        }

        public async Task<State> GetById(int id)
        {
            return await _gaHealthcareNursesContext.State.Where(x => x.StateId== id).FirstOrDefaultAsync();
        }
        #endregion
    }
}
