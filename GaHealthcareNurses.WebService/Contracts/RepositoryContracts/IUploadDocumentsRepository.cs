using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
  public interface IUploadDocumentsRepository
    {
        Task<IEnumerable<UploadDocuments>> Get();
        Task<UploadDocuments> GetById(string id);
        Task AddDocument(UploadDocuments documents);
        Task UpdateDocument(UploadDocuments documents);
    }
}
