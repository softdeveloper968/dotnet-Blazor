using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;

namespace GaHealthcareNurses.Entity.Mapping
{
    public static class NurseMappingProfile
    {

        public static Nurse GetMappedNurseData(UserViewModel registrationViewModel, Nurse nurse, string stepsInformationSerialize)
        {
            nurse.FirstName = registrationViewModel.SignUp.FirstName;
            nurse.LastName = registrationViewModel.SignUp.LastName;
            nurse.MiddleInitial = registrationViewModel.SignUp.MiddleInitial;
            nurse.DateOfBirth = registrationViewModel.SignUp.DateOfBirth;
            nurse.AddressLine1 = registrationViewModel.SignUp.AddressLine1;
            nurse.AddressLine2 = registrationViewModel.SignUp.AddressLine2;
            nurse.CityId = registrationViewModel.SignUp.CityId;
            nurse.StateId = registrationViewModel.SignUp.StateId;
            nurse.ZipCode = registrationViewModel.SignUp.ZipCode;
            nurse.Latitude = registrationViewModel.SignUp.Latitude;
            nurse.Longitude = registrationViewModel.SignUp.Longitude;
            nurse.TelephoneNo = registrationViewModel.SignUp.TelephoneNo;
            nurse.EmailAddress = registrationViewModel.SignUp.EmailAddress;
            nurse.SocialSecurityNo = registrationViewModel.SignUp.SocialSecurityNo;
            nurse.FirebaseToken = registrationViewModel.SignUp.FirebaseToken;
            nurse.DeviceType = registrationViewModel.SignUp.DeviceType;
            //nurse.CreatedDate = registrationViewModel.SignUp.CreatedDate;
            //nurse.UpdatedDate = registrationViewModel.SignUp.UpdatedDate;

            nurse.ContactTime = registrationViewModel.BasicInfo.ContactTime;
            nurse.ContactPresentEmployer = registrationViewModel.BasicInfo.ContactPresentEmployer;
            nurse.LawfullyBecomingEmployed = registrationViewModel.BasicInfo.LawfullyBecomingEmployed;
            nurse.DateAvailableToWork = registrationViewModel.BasicInfo.DateAvailableToWork;
            nurse.HoursPerWeek = registrationViewModel.BasicInfo.HoursPerWeek;
            nurse.AvailableToWork = registrationViewModel.BasicInfo.AvailableToWork;
            nurse.Trasnportation = registrationViewModel.BasicInfo.Trasnportation;
            nurse.IneligibleForParticipation = registrationViewModel.BasicInfo.IneligibleForParticipation;
            nurse.ReasonForIneligible = registrationViewModel.BasicInfo.ReasonForIneligible;
            nurse.CriminalActivity = registrationViewModel.BasicInfo.CriminalActivity;
            nurse.EmergencyContactName = registrationViewModel.Finish.EmergencyContactName;
            nurse.EmergencyContactAddress = registrationViewModel.Finish.EmergencyContactAddress;
            nurse.EmergencyContactPhone = registrationViewModel.Finish.EmergencyContactPhone;
            nurse.EmergencyContactRelationship = registrationViewModel.Finish.EmergencyContactRelationship;
            nurse.ReasonForWork = registrationViewModel.Finish.ReasonForWork;
            nurse.ProfliePicture = registrationViewModel.Finish.ProfliePicture;
            nurse.Resume = registrationViewModel.Finish.Resume;
            nurse.StepsInformation = stepsInformationSerialize;
            nurse.AgreeToApplicantStatement = registrationViewModel.Finish.AgreeToApplicantStatement;
            nurse.AgreeToNonDiscriminationDocument = registrationViewModel.Finish.AgreeToNonDiscriminationDocument;
            return nurse;
        }


        //public static Nurse GetMappedReferralNurseData(ReferralSignUp signUpViewModel, Nurse nurse)
        //{
        //    nurse.FirstName = signUpViewModel.FirstName;
        //    nurse.LastName = signUpViewModel.LastName;
        //    nurse.MiddleInitial = signUpViewModel.MiddleInitial;
        //    nurse.DateOfBirth = signUpViewModel.DateOfBirth;
        //    nurse.AddressLine1 = signUpViewModel.AddressLine1;
        //    nurse.AddressLine2 = signUpViewModel.AddressLine2;
        //    nurse.CityId = signUpViewModel.CityId;
        //    nurse.StateId = signUpViewModel.StateId;
        //    nurse.ZipCode = signUpViewModel.ZipCode;
        //    nurse.Latitude = signUpViewModel.Latitude;
        //    nurse.Longitude = signUpViewModel.Longitude;
        //    nurse.TelephoneNo = signUpViewModel.TelephoneNo;
        //    nurse.EmailAddress = signUpViewModel.EmailAddress;
        //    nurse.SocialSecurityNo = signUpViewModel.SocialSecurityNo;
        //    nurse.FirebaseToken = signUpViewModel.FirebaseToken;
        //    nurse.DeviceType = signUpViewModel.DeviceType;
        //    return nurse;
        //}
    }
}
