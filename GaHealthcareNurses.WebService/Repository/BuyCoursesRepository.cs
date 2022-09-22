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
    public class BuyCoursesRepository : IBuyCoursesRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For BuyCoursesRepository
        public BuyCoursesRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
       

      public async Task AddPurchasedCourse(BuyCourses courses)
        {
            await _gaHealthcareNursesContext.BuyCourses.AddAsync(courses);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<bool> CourseExist(string paymentId)
        {
           return await _gaHealthcareNursesContext.BuyCourses.Where(x => x.PaymentId == paymentId).AnyAsync();
        }

        #endregion
    }
}
