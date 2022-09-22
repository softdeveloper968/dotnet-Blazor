using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
   public interface IFileUploadService
    {
        Task<Nurse> UploadFiles(UploadFileViewModel fileViewModel);
        Task<bool> DeleteProfilePicture(string id);
    }
}
