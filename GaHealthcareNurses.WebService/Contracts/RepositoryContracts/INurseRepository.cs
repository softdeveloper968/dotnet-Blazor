using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface INurseRepository
    {
        Task<IEnumerable<Nurse>> GetAllNurses();
        Task<Nurse> GetNurseById(string id);
        Task AddNurse(Nurse nurse);
        Task UpdateNurse(Nurse nurse);
        Task DeleteNurse(Nurse nurse);
        Task<IEnumerable<Nurse>> GetAllNursesByCreatedDate(int skip, int take, string filter);
        Task<int> GetAllNursesCount(string filter);
        Task<List<Nurse>> GetNursesDetails();
        Task<Referral> AddReferral(Referral referral);
        Task<Nurse> GetNurseByEmailId(string emailAddress);
        Task UpdateReferral(Referral referral);
        Task<Referral> GetReferralById(int referralId);
        Task<Referral> GetReferralNursebyEmailId(string emailAddress,string nurseId);
    }
}
