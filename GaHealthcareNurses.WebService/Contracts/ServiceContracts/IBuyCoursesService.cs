using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IBuyCoursesService
    {
        Task AddPurchasedCourse(BuyCourses courses);
        Task<bool> CourseExist(string paymentId);
    }
}
