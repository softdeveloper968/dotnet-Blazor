using AutoMapper;
using GaHealthcareNurses.Client.Data.ViewModels;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;

namespace GaHealthcareNurses.Client.Data
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<NurseSignUp, SignUp>();
            CreateMap<EmployerSignUp, EmployerViewModel>();
            CreateMap<ClientSignUp, ClientViewModel>();
            CreateMap<CareRecipientInformationModel, CareRecipientViewModel>();
            CreateMap<Employer, EmployerUpdateViewModel>().ForMember(x=>x.Logo,opt=>opt.Ignore()).ForMember(x=>x.EmployerId,opt=>opt.MapFrom(x=>x.Id));
            CreateMap<NurseSignUp, ReferralSignUp>();
        }
    }
}
