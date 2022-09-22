using Contracts;
using GaHealthcareNurses.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    //
  //public class NurseRepository: INurseRepository
  //  {
  //      private GaHealthcareNursesContext _gaHealthcareNursesContext;

  //      #region Contructor For NurseRepository
  //      public NurseRepository(GaHealthcareNursesContext context)
  //      {
  //          _gaHealthcareNursesContext = context;
  //      }
  //      #endregion

  //      #region Implementing Interface
  //      public async Task AddNurse(Nurse nurse)
  //      {
  //         await _gaHealthcareNursesContext.Nurse.AddAsync(nurse);
  //         await _gaHealthcareNursesContext.SaveChangesAsync();
  //      }

  //      public async Task DeleteNurse(Nurse nurse)
  //      {
  //          _gaHealthcareNursesContext.Nurse.Remove(nurse);
  //         await _gaHealthcareNursesContext.SaveChangesAsync();
  //      }

  //      public async Task<IEnumerable<Nurse>> GetAllNurses()
  //      {
  //          return await _gaHealthcareNursesContext.Nurse.ToListAsync();
  //      }

  //      public async Task<Nurse> GetNurseById(string id)
  //      {
  //          return await _gaHealthcareNursesContext.Nurse.Where(x=>x.Id == id).FirstOrDefaultAsync();
  //      }

  //      public async Task UpdateNurse(Nurse nurse)
  //      {
  //          _gaHealthcareNursesContext.Nurse.Update(nurse);
  //          await _gaHealthcareNursesContext.SaveChangesAsync();
  //      }
  //      #endregion
  //  }
}
