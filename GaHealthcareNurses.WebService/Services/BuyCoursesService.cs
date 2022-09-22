using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Common;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Repository;
using Services.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BuyCoursesService : IBuyCoursesService
    {
        private IBuyCoursesRepository _buyCoursesRepository;

        #region Constructor for BuyCoursesService
        public BuyCoursesService(IBuyCoursesRepository buyCoursesRepository)
        {
            _buyCoursesRepository = buyCoursesRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task AddPurchasedCourse(BuyCourses courses)
        {
            await _buyCoursesRepository.AddPurchasedCourse(courses);
        }

        public async Task<bool> CourseExist(string paymentId)
        {
            return await _buyCoursesRepository.CourseExist(paymentId);
        }

        #endregion
    }
}
