using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBuyCoursesRepository
    {
        Task AddPurchasedCourse(BuyCourses courses);
        Task<bool> CourseExist(string paymentId);
    }
}
