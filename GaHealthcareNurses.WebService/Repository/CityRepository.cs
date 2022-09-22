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
    public class CityRepository : ICityRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For EmployerRepository
        public CityRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<City>> Get()
        {
            return await _gaHealthcareNursesContext.City.ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _gaHealthcareNursesContext.City.Where(x => x.CityId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> GetByStateId(int stateId)
        {
            return await _gaHealthcareNursesContext.City.Where(x => x.StateId == stateId).OrderBy(x => x.Name).ToListAsync();
        }
        #endregion
    }
}
