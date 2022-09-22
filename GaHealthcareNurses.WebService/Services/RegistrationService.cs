using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using Services.Helper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using GaHealthcareNurses.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GaHealthcareNurses.Entity.Mapping;
using GaHealthcareNurses.Entity.Common;
using System;

namespace Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly INurseService _nurseService;
        private readonly IWorkExperienceService _workExperienceService;
        private readonly IEducationService _educationService;
        private readonly IEducationTypeService _educationTypeService;
        private readonly ICertificationService _certificationService;
        private readonly IReferenceService _referenceService;
        private readonly IEmployerService _employerService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Constructor for EmployerService
        public RegistrationService(INurseService nurseService, IMapper mapper, IWorkExperienceService workExperienceService, IEducationService educationService, ICertificationService certificationService, IReferenceService referenceService, IEducationTypeService educationTypeService, GaHealthcareNursesContext gaHealthcareNursesContext, UserManager<IdentityUser> userManager, IEmployerService employerService, IClientService clientService)
        {
            _userManager = userManager;
            _nurseService = nurseService;
            _workExperienceService = workExperienceService;
            _mapper = mapper;
            _educationService = educationService;
            _educationTypeService = educationTypeService;
            _certificationService = certificationService;
            _referenceService = referenceService;
            _gaHealthcareNursesContext = gaHealthcareNursesContext;
            _employerService = employerService;
            _clientService = clientService;
        }
        #endregion

        #region Implementing Interface

        public async Task Add(UserViewModel registrationViewModel, IdentityUser user)
        {
            var stepsInformation = await GetStepsInfomation(registrationViewModel);

            var nurse = await AddNurse(registrationViewModel, stepsInformation, user);

            await AddWorkExperience(registrationViewModel, nurse);

            var educationType = await AddEducationType(registrationViewModel);

            await AddEducation(registrationViewModel, educationType, nurse);

            await AddCertification(registrationViewModel, nurse);

            await AddReference(registrationViewModel, nurse);
        }

        public async Task<bool> ChangePassword(IdentityUser aspuser, ResetPasswordModel model)
        {
            return await Changepassword(aspuser, model);
        }

        public async Task<UserViewModel> GetById(string id)
        {
            var nurse = await _gaHealthcareNursesContext.Nurse.Include(i => i.WorkExperiences).Include(i => i.Educations).Include(i => i.Certifications).Include(i => i.References).Where(x => x.Id == id).FirstOrDefaultAsync();
            var signUp = _mapper.Map<SignUp>(nurse);
            var basicInfo = _mapper.Map<BasicInfo>(nurse);
            var check = StepsInformationChecker.StepsInfoCheck(basicInfo);
            var workExperience = _mapper.Map<WorkExperienceViewModel>(nurse);
            var education = _mapper.Map<EducationViewModel>(nurse);
            var finish = _mapper.Map<Finish>(nurse);
            UserViewModel user = new UserViewModel();
            user.SignUp = signUp;
            user.BasicInfo = basicInfo;
            user.WorkExperience = workExperience;
            user.Education = education;
            user.Finish = finish;
            return user;
        }

        public async Task<AccountViewModel> GetAdditionalData(IdentityUser aspnetuser)
        {
            return await GetAdditionalDatamethod(aspnetuser);
        }

        public async Task<bool> SendEmailToUser(AccountViewModel accountViewModel, string templatePath, string type, string addedBy = null)
        {
            return await SendEmailTouser(accountViewModel, templatePath, type, addedBy = null);
        }

        public async Task Update(UserViewModel registrationViewModel)
        {
            var stepsInformation = await GetStepsInfomation(registrationViewModel);

            var nurse = await UpdateNurse(registrationViewModel, stepsInformation);

            await UpdateWorkExperience(registrationViewModel, nurse);

            // var educationType= await UpdateEducationType(registrationViewModel);

            await UpdateEducation(registrationViewModel, nurse);

            await UpdateCertification(registrationViewModel, nurse);

            await UpdateReference(registrationViewModel, nurse);

        }

        public async Task<Employer> AddEmployer(EmployerViewModel employer, IdentityUser user)
        {
            var employerData = _mapper.Map<Employer>(employer);
            employerData.Id = user.Id;
            if (employer.Logo != null)
            {
                var logoPath = UploadAndDownloadFileAzure.UploadDocument(employer.Logo, user.Id);
                employerData.Logo = logoPath;
            }
            await _employerService.Add(employerData);
            return employerData;

        }
        public async Task<Client> AddClient(ClientViewModel client, IdentityUser user)
        {
            var clientData = _mapper.Map<Client>(client);
            clientData.Id = user.Id;
            await _clientService.Add(clientData);
            return clientData;
        }

        #endregion

        private async Task<Nurse> AddNurse(UserViewModel registrationViewModel, string stepsInformationSerialize, IdentityUser user)
        {
            var nurseData = _mapper.Map<Nurse>(registrationViewModel.SignUp);
            nurseData.Id = user.Id;
            nurseData.CreatedDate = DateTime.Now;
            nurseData.UpdatedDate = DateTime.Now;
            var nurse = NurseMappingProfile.GetMappedNurseData(registrationViewModel, nurseData, stepsInformationSerialize);
            await _nurseService.Add(nurse);
            return nurse;
        }


        private async Task AddWorkExperience(UserViewModel registrationViewModel, Nurse nurse)
        {
            var workExperienceList = _mapper.Map<List<WorkExperience>>(registrationViewModel.WorkExperience.WorkExperienceDto);
            foreach (var workExperience in workExperienceList)
            {
                workExperience.NurseId = nurse.Id;
                workExperience.Nurse = nurse;
                await _workExperienceService.Add(workExperience);
            }
        }

        private async Task<List<EducationType>> AddEducationType(UserViewModel registrationViewModel)
        {
            var educationTypeList = _mapper.Map<List<EducationType>>(registrationViewModel.Education.EducationDto);
            foreach (var educationType in educationTypeList)
            {
                await _educationTypeService.Add(educationType);

            }
            return educationTypeList;
        }


        private async Task AddEducation(UserViewModel registrationViewModel, List<EducationType> educationTypes, Nurse nurse)
        {
            var educationList = _mapper.Map<List<Education>>(registrationViewModel.Education.EducationDto);
            foreach (var education in educationList)
            {
                foreach (var educationType in educationTypes)
                {
                    education.EducationTypeId = educationType.EducationTypeId;
                    education.NurseId = nurse.Id;
                    education.Nurse = nurse;
                }
                await _educationService.Add(education);
            }
        }


        private async Task AddCertification(UserViewModel registrationViewModel, Nurse nurse)
        {
            var certificationList = _mapper.Map<List<Certification>>(registrationViewModel.Education.CertificationDto);
            foreach (var certification in certificationList)
            {
                certification.NurseId = nurse.Id;
                certification.Nurse = nurse;
                certification.StateId = nurse.StateId;
                await _certificationService.Add(certification);
            }
        }


        private async Task AddReference(UserViewModel registrationViewModel, Nurse nurse)
        {
            var referenceList = _mapper.Map<List<Reference>>(registrationViewModel.Finish.ReferenceDto);
            foreach (var reference in referenceList)
            {
                reference.NurseId = nurse.Id;
                reference.Nurse = nurse;
                await _referenceService.Add(reference);
            }
        }


        private async Task<Nurse> UpdateNurse(UserViewModel registrationViewModel, string stepsInformationSerialize)
        {
            var nurseData = await _nurseService.GetById(registrationViewModel.SignUp.Id);
            //  nurseData. = _mapper.Map<Nurse>(registrationViewModel.SignUp);
            // var nurseData = _mapper.Map<Nurse>(registrationViewModel.SignUp);
            // nurseData.Id = registrationViewModel.SignUp.Id;
            nurseData.UpdatedDate = DateTime.Now;
            var nurse = NurseMappingProfile.GetMappedNurseData(registrationViewModel, nurseData, stepsInformationSerialize);
            await _nurseService.Update(nurse);
            return nurse;
        }


        private async Task UpdateWorkExperience(UserViewModel registrationViewModel, Nurse nurse)
        {
            var workExperienceList = _mapper.Map<List<WorkExperience>>(registrationViewModel.WorkExperience.WorkExperienceDto);
            foreach (var workExperience in workExperienceList)
            {
                workExperience.NurseId = nurse.Id;
                await _workExperienceService.Update(workExperience);
            }
        }


        //private async Task<List<EducationType>> UpdateEducationType(UserViewModel registrationViewModel)
        //{
        //    var educationTypeList = _mapper.Map<List<EducationType>>(registrationViewModel.Education.EducationDto);
        //    foreach (var educationType in educationTypeList)
        //    {
        //        await _educationTypeService.Update(educationType);

        //    }
        //    return educationTypeList;
        //}


        private async Task UpdateEducation(UserViewModel registrationViewModel, Nurse nurse)
        {
            var educationList = _mapper.Map<List<Education>>(registrationViewModel.Education.EducationDto);
            foreach (var education in educationList)
            {
                education.NurseId = nurse.Id;
                await _educationService.Update(education);
            }


        }


        private async Task UpdateCertification(UserViewModel registrationViewModel, Nurse nurse)
        {
            var certificationList = _mapper.Map<List<Certification>>(registrationViewModel.Education.CertificationDto);
            foreach (var certification in certificationList)
            {
                certification.NurseId = nurse.Id;
                await _certificationService.Update(certification);
            }
        }


        private async Task UpdateReference(UserViewModel registrationViewModel, Nurse nurse)
        {
            var referenceList = _mapper.Map<List<Reference>>(registrationViewModel.Finish.ReferenceDto);
            foreach (var reference in referenceList)
            {
                reference.NurseId = nurse.Id;
                await _referenceService.Update(reference);
            }
        }


        private async Task<string> GetStepsInfomation(UserViewModel registrationViewModel)
        {
            List<StepsInformation> stepsInformation = new List<StepsInformation>();

            var firstStepInformation = StepsInformationChecker.SetProperties(registrationViewModel.SignUp);
            stepsInformation.Add(firstStepInformation);

            var secondStepInformation = StepsInformationChecker.SetProperties(registrationViewModel.BasicInfo);
            stepsInformation.Add(secondStepInformation);

            var thirdStepInformation = StepsInformationChecker.SetProperties(registrationViewModel.WorkExperience);
            stepsInformation.Add(thirdStepInformation);

            var fourthStepInformation = StepsInformationChecker.SetProperties(registrationViewModel.Education);
            stepsInformation.Add(fourthStepInformation);

            var fifthStepInformation = StepsInformationChecker.SetProperties(registrationViewModel.Finish);
            stepsInformation.Add(fifthStepInformation);

            return JsonConvert.SerializeObject(stepsInformation);
        }


        /// <summary>
        /// Used for sending the email for register and forgot password
        /// </summary>
        /// <param name="accountViewModel"></param>
        public async Task<bool> SendEmailTouser(AccountViewModel accountViewModel, string templatePath, string type, string addedBy = null)
        {
            try
            {
                string emailBody = string.Empty;
                emailBody = Utility.GetEmailTemplateValue(templatePath, "ForgotPasswordEmail/Body");
                emailBody = emailBody.Replace("@@@username", accountViewModel.FirstName + " " + accountViewModel.LastName);
                emailBody = emailBody.Replace("@@@Token", accountViewModel.token);
                emailBody = emailBody.Replace("@@@id", accountViewModel.UserName);

                Utility.SendMailToUser(EnumHelper.GetDescription(EmailSubjectRole.ResetPassword), accountViewModel.Email, emailBody);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Get additonal data of user.
        /// </summary>
        /// <param name="aspNetUsers"></param>
        /// <returns></returns>
        private async Task<AccountViewModel> GetAdditionalDatamethod(IdentityUser aspnetuser)
        {
            var nurseData = await _nurseService.GetById(aspnetuser.Id);
            var clientData = await _clientService.GetById(aspnetuser.Id);
            var employerData = await _employerService.GetById(aspnetuser.Id);
            if (nurseData != null)
            {
                return new AccountViewModel()
                {
                    Email = aspnetuser.Email,
                    PhoneNumber = nurseData.TelephoneNo,
                    FirstName = nurseData.FirstName,
                    LastName = nurseData.LastName,
                    UserName = aspnetuser.Id

                };
            }
            else if (clientData != null)
            {
                return new AccountViewModel()
                {
                    Email = aspnetuser.Email,
                    PhoneNumber = clientData.Phone1,
                    FirstName = clientData.FirstName,
                    LastName = clientData.LastName,
                    UserName = aspnetuser.Id

                };
            }
            else
            {
                return new AccountViewModel()
                {
                    Email = aspnetuser.Email,
                    PhoneNumber = employerData.TelephoneNo,
                    FirstName = employerData.Name,
                    LastName = string.Empty,
                    UserName = aspnetuser.Id

                };
            }

        }

        /// <summary>
        ///  for saving the change password
        /// </summary>
        /// <param name="aspNetUsers"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private async Task<bool> Changepassword(IdentityUser aspuser, ResetPasswordModel model)
        {
            try
            {
                if (model != null)
                {
                    IdentityResult result = _userManager.ResetPasswordAsync
             (aspuser, model.Token, model.Password).Result;

                    if (result.Succeeded)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            return true;
        }
        public async Task<Nurse> AddReferralNurse(ReferralSignUp referralViewModel, IdentityUser user)
        {
            try
            {
                var nurseData = _mapper.Map<Nurse>(referralViewModel);
                nurseData.Id = user.Id;
                nurseData.CreatedDate = DateTime.Now;
                nurseData.UpdatedDate = DateTime.Now;
                await _nurseService.Add(nurseData);
                var referral = await _nurseService.GetReferralById(referralViewModel.ReferralId);

                //update registered date in referral table
                referral.DateRegistered = DateTime.Now;
                await _nurseService.UpdateReferral(referral);

                //add count for refferal
                var nurseDetail = await _nurseService.GetById(referral.NurseId);
                nurseDetail.UpdatedDate = DateTime.Now;
                nurseDetail.RegisteredCount = nurseDetail.RegisteredCount == null ? 1 : nurseDetail.RegisteredCount + 1;

                //var rewardCount = nurseDetail.ReferralCount / 25 == 0;
                //if (nurseDetail.ReferralCount => 25)
                //{
                //    nurseDetail.TotalRewards= nurseDetail.TotalRewards == null ? 1 : nurseDetail.TotalRewards + 1;
                //}
                await _nurseService.Update(nurseDetail);


                return nurseData;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }


}
