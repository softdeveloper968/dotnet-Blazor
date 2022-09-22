using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
  public interface IRegistrationService
    {
        Task Add(UserViewModel registrationViewModel,IdentityUser user);
        Task<UserViewModel> GetById(string id);
        Task Update(UserViewModel registrationViewModel);
        Task<AccountViewModel> GetAdditionalData(IdentityUser aspnetuser);
        Task<bool> SendEmailToUser(AccountViewModel accountViewModel, string templatePath, string type, string addedBy = null);
        Task <bool> ChangePassword(IdentityUser aspuser, ResetPasswordModel resetPasswordModel);
        Task<Employer> AddEmployer(EmployerViewModel employer, IdentityUser user);
        Task<Client> AddClient(ClientViewModel client, IdentityUser user);
        // Task UpdateReferral(Referral referral);
        Task<Nurse> AddReferralNurse(ReferralSignUp referralViewModel, IdentityUser user);
    }
}
