using Contracts;
using GaHealthcareNurses.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using GaHealthcareNurses.Entity.ViewModels;

namespace Repository
{
    //
    public class NurseRepository : INurseRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For NurseRepository
        public NurseRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task AddNurse(Nurse nurse)
        {
            try
            {
                await _gaHealthcareNursesContext.Nurse.AddAsync(nurse);
                await _gaHealthcareNursesContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteNurse(Nurse nurse)
        {
            _gaHealthcareNursesContext.Nurse.Remove(nurse);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nurse>> GetAllNurses()
        {
            return await _gaHealthcareNursesContext.Nurse.ToListAsync();
        }

        public async Task<Nurse> GetNurseById(string id)
        {
            return await _gaHealthcareNursesContext.Nurse.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateNurse(Nurse nurse)
        {
            _gaHealthcareNursesContext.Nurse.Update(nurse);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Nurse>> GetAllNursesByCreatedDate(int skip, int take, string filter)
        {
            try
            {
                if (filter != null)
                {
                    var filteredRecords = await _gaHealthcareNursesContext.Nurse.Include(x => x.WorkExperiences).Include(x => x.Educations).Include(x =>x.Educations).Include(x => x.Certifications).Include(x => x.City).Include(x => x.References).Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter) || x.AddressLine1.Contains(filter) || x.EmailAddress.Contains(filter) || x.DateOfBirth.ToString().Contains(filter)).OrderByDescending(x => x.CreatedDate).ToListAsync();

                    return filteredRecords.Skip(skip).Take(take).ToList();
                }
                var result = await _gaHealthcareNursesContext.Nurse.Include(x => x.WorkExperiences).Include(x => x.Educations).Include(x => x.Certifications).Include(x => x.City).Include(x => x.References).OrderByDescending(x => x.CreatedDate).Skip(skip).Take(take).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> GetAllNursesCount(string filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter))
                    return await _gaHealthcareNursesContext.Nurse.OrderByDescending(x => x.CreatedDate).CountAsync();

                return await _gaHealthcareNursesContext.Nurse.Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter) || x.AddressLine1.Contains(filter) || x.DateOfBirth.ToString().Contains(filter) || x.CreatedDate.ToString().Contains(filter)).OrderByDescending(x => x.CreatedDate).CountAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<Nurse>> GetNursesDetails()
        {
            try
            {
                return await _gaHealthcareNursesContext.Nurse.Include(x => x.State).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Nurse> GetNurseByEmailId(string emailAddress)
        {
            return await _gaHealthcareNursesContext.Nurse.Where(x => x.EmailAddress == emailAddress).FirstOrDefaultAsync();
        }
        //public async Task<Referral> GetNursereferralById(string nurseId,string emailAddress)
        //{
        //    return await _gaHealthcareNursesContext.Referral.Where(x => x.EmailAddress == emailAddress && x.NurseId==nurseId).FirstOrDefaultAsync();
        //}
        public async Task<Referral> AddReferral(Referral referral)
        {
            await _gaHealthcareNursesContext.Referral.AddAsync(referral);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return referral;
        }

        public async Task UpdateReferral(Referral referral)
        {
            _gaHealthcareNursesContext.Referral.Update(referral);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        public async Task<Referral> GetReferralById(int referralId)
        {
            return await _gaHealthcareNursesContext.Referral.Where(x => x.ReferralId == referralId).FirstOrDefaultAsync();

        }
       public async Task<Referral> GetReferralNursebyEmailId(string emailAddress,string nurseId)
        {
            return await _gaHealthcareNursesContext.Referral.Where(x => x.EmailAddress == emailAddress && x.NurseId==nurseId).FirstOrDefaultAsync();
        }
        #endregion
    }
}
