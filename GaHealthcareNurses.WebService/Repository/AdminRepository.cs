using Contracts;
using GaHealthcareNurses.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using GaHealthcareNurses.Entity.ViewModels;

namespace Repository
{
    //
    public class AdminRepository : IAdminRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For AdminRepository
        public AdminRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
       

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _gaHealthcareNursesContext.Admin.ToListAsync();
        }

        public async Task<Admin> GetAdminById(int id)
        {
            return await _gaHealthcareNursesContext.Admin.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
       
        #endregion
    }
}
