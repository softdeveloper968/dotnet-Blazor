using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Contracts.RepositoryContracts;

namespace Repository
{
    public class UploadDocumentsRepository : IUploadDocumentsRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For UploadDocumentsRepository
        public UploadDocumentsRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface

        public async Task AddDocument(UploadDocuments documents)
        {
            await _gaHealthcareNursesContext.Documents.AddAsync(documents);

            await _gaHealthcareNursesContext.SaveChangesAsync();
        }
        public async Task UpdateDocument(UploadDocuments documents)
        {
            _gaHealthcareNursesContext.Documents.Update(documents);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UploadDocuments>> Get()
        {
            return await _gaHealthcareNursesContext.Documents.ToListAsync();
        }

        public async Task<UploadDocuments> GetById(string id)
        {
            return await _gaHealthcareNursesContext.Documents.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        #endregion
    }
}
