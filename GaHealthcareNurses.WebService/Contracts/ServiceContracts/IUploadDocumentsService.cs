using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IUploadDocumentsService
    {
        Task<IEnumerable<UploadDocuments>> Get();
        Task<UploadDocuments> GetById(string id);
        Task AddDocument(UploadDocuments documents);
        Task UpdateDocument(UploadDocuments documents);
        Task<UploadDocuments> UploadDocuments(UploadDocumentsViewModel uploadDocuments);
        Task<UploadDocuments> UpdateDocuments(UploadDocumentsViewModel uploadDocuments);
    }
}
