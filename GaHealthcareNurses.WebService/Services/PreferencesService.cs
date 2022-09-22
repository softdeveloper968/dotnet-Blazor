using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.ViewModels;
using GaHealthcareNurses.Entity.Models;
using System.Threading.Tasks;
using Services.Helper;

namespace Services
{
    public class PreferencesService : IPreferencesService
    {
        private INurseService _nurseService;
        public PreferencesService(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        public async Task<Nurse> AddPreferences(PreferencesViewModel preferences)
        {
            var nurseData = await _nurseService.GetById(preferences.UserId);
            nurseData.AvailableHoursPerWeek = preferences.AvailableHoursPerWeek;
            nurseData.PreferredHourlyRate = preferences.PreferredHourlyRate;
            nurseData.PreferredHourlyRateUpto = preferences.PreferredHourlyRateUpto;
            await _nurseService.Update(nurseData);
            return nurseData;
        }

        public async Task<Nurse> GetById(string id)
        {
            var nurseData = await _nurseService.GetById(id);
            return nurseData;
        }
    }
}