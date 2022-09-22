using AutoMapper;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;

namespace Services
{
  public class AutomapperConfig:Profile
    {
        public AutomapperConfig()
        {
            CreateMap<SignUp, Nurse>();
            CreateMap<WorkExperienceDto, WorkExperience>();
            CreateMap<EducationDto, EducationType>();
            CreateMap<EducationDto, Education>();
            CreateMap<CertificationDto, Certification>();
            CreateMap<ReferenceDto, Reference>();
            CreateMap<EmployerViewModel, Employer>();
            CreateMap<HiringAggrementsViewModel, HiringAgreements>();
            CreateMap<ClientViewModel, Client>();
            CreateMap<JobViewModel, Job>();
            CreateMap<Nurse, SignUp>().ForMember(x=>x.Password,opt=>opt.Ignore());
            CreateMap<Nurse, BasicInfo>();
            CreateMap<WorkExperience, WorkExperienceDto>();
            CreateMap<Nurse, WorkExperienceViewModel>().ForMember(x=>x.WorkExperienceDto,opt=>opt.MapFrom(x=>x.WorkExperiences));
            CreateMap<Education, EducationDto>().ForMember(x => x.Name, opt => opt.Ignore());
            CreateMap<Certification, CertificationDto>();
            CreateMap<Nurse, EducationViewModel>().ForMember(x => x.EducationDto, opt => opt.MapFrom(x => x.Educations)).ForMember(x=>x.CertificationDto,opt=>opt.MapFrom(x=>x.Certifications));
            CreateMap<Reference, ReferenceDto>();
            CreateMap<Nurse, Finish>().ForMember(x=>x.ReferenceDto,opt=>opt.MapFrom(x=>x.References));
            CreateMap<CareRecipientViewModel, CareRecipient>();
            CreateMap<JobApplyViewModel, JobApply>();
            CreateMap<Job, GetJobsViewModel>();
            CreateMap<TaskListViewModel, TaskList>();
            CreateMap<AddSignatureViewModel, GetTaskListByDate>();
            CreateMap<JobApplyForAgencyViewModel, JobApplyForAgency>();
            CreateMap<Job, GetJobsForAgencyViewModel>();
            CreateMap<TaskListTemplateViewModel, TaskListTemplate>();
            CreateMap<Employer, EmployerViewModel>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<ReferralSignUp, Nurse>();
        }
    }
}
