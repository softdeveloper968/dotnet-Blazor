using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
   public interface IPreferencesService
    {
        Task<Nurse> AddPreferences(PreferencesViewModel preferences);
        Task<Nurse> GetById(string id);
    }
}
