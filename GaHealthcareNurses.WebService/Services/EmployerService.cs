using AutoMapper;
using Contracts;
using Contracts.ServiceContracts;
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
    public class EmployerService : IEmployerService
    {
        private IEmployerRepository _employerRepository;
        private IMapper _mapper;

        #region Constructor for EmployerService
        public EmployerService(IEmployerRepository employerRepository,IMapper mapper)
        {
            _employerRepository = employerRepository;
            _mapper = mapper;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Employer>> Get(int skip, int take, string filter)
        {
            return await _employerRepository.Get(skip,take,filter);
        }

        public async Task<IEnumerable<Employer>> GetAll()
        {
            return await _employerRepository.GetAll();
        }
        public async Task<int> TotalCount(string filter)
        {
            return await _employerRepository.TotalCount(filter);
        }

        public async Task<Employer> GetById(string id)
        {
            return await _employerRepository.GetById(id);
        }
        public async Task<bool> GetByName(Employer employer)
        {
            return await _employerRepository.GetByName(employer);
        }

        public async Task Add(Employer employer)
        {
          await _employerRepository.Add(employer);
        }

        public async Task Delete(Employer employer)
        {
            await _employerRepository.Delete(employer);
        }

        public async Task<Employer> Update(EmployerViewModel employer)
        {
            var employerData = await _employerRepository.GetById(employer.EmployerId);
            employerData.Name = employer.Name;
            employerData.AddressLine1 = employer.AddressLine1;
            employerData.AddressLine2 = employer.AddressLine2;
            employerData.CityId = employer.CityId;
            employerData.StateId = employer.StateId;
            employerData.ZipCode = employer.ZipCode;
            employerData.TelephoneNo = employer.TelephoneNo;
            employerData.EmailAddress = employer.EmailAddress;

            if (employer.Logo != null)
            {
                var logoPath = UploadAndDownloadFileAzure.UploadDocument(employer.Logo, employerData.Id);
                employerData.Logo = logoPath;
            }
          return await _employerRepository.Update(employerData);

        }
        #endregion
    }
}
