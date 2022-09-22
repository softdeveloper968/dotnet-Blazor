using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface INurseService
    {
       Task <IEnumerable<Nurse>> GetAll();
       Task<Nurse> GetById(string id);
        Task Add(Nurse nurse);
        Task Delete(Nurse nurse);
        Task Update(Nurse nurse);
        Task<Nurse> ChangeUserJobAvailability(JobAvailabilityViewModel jobAvailability);
        Task<IEnumerable<Nurse>> GetbyCreatedDate(int skip, int take, string filter);
        Task<int> GetNursesCount(string filter);
        Task<IEnumerable<NurseDetails>> GetNurses();
        Task<string> AddReferral(SendReferralViewModel sendReferralViewModel);
        Task UpdateReferral(Referral referral);
       Task<Referral> GetReferralById(int referralId);
        Task<string> ClaimReward(string nurseId);
        Task<string> BuyCourses(string nurseId);
        Task<bool> ExecutePayment(string paymentId, string payerId);
    }
}
