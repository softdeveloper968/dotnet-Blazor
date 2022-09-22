using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.ViewModels;
using GaHealthcareNurses.Entity.Models;
using System.Threading.Tasks;
using Services.Helper;

namespace Services
{
    public class FileUploadService : IFileUploadService
    {
        private INurseService _nurseService;
        public FileUploadService(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        public async Task<Nurse> UploadFiles(UploadFileViewModel fileViewModel)
        {
            var nurseData = await _nurseService.GetById(fileViewModel.UserId);
            string id = string.Empty;
            if (fileViewModel.ProfileImage != null)
            {
                var profilePicFilePath = UploadAndDownloadFileAzure.UploadDocument(fileViewModel.ProfileImage, fileViewModel.UserId);
                nurseData.ProfliePicture = profilePicFilePath;
            }
            if (fileViewModel.ResumeFile != null)
            {
                var resumeFilePath = UploadAndDownloadFileAzure.UploadDocument(fileViewModel.ResumeFile, fileViewModel.UserId);
                nurseData.Resume = resumeFilePath;
            }
            await _nurseService.Update(nurseData);
            return nurseData;
        }


        public async Task<bool> DeleteProfilePicture(string id)
        {
            var nurseData = await _nurseService.GetById(id);
            BlobStorageService blobStorageService = new BlobStorageService();
            var isDeleted=  await blobStorageService.DeleteBlobData(nurseData.ProfliePicture,id);
            if(isDeleted)
            {
                nurseData.ProfliePicture =string.Empty;
                await _nurseService.Update(nurseData);
            }
            return isDeleted;
        }
    }
}