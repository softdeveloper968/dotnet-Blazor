using Microsoft.AspNetCore.Http;
using System.IO;

namespace Services.Helper
{
    public static class UploadAndDownloadFileAzure
    {
        public static string UploadDocument(IFormFile document, string userId)
        {
            var uploads = Path.Combine("./Uploads");
            bool exists = Directory.Exists(uploads);
            if (!exists)
                Directory.CreateDirectory(uploads);
            string file = document.FileName;
            string fileName = Path.GetFileName(userId);
            byte[] fileData;
            using (var target = new MemoryStream())
            {
                document.CopyTo(target);
                fileData = target.ToArray();
            }


            //var fileStream = new FileStream(Path.Combine(uploads, product.File.FileName), FileMode.Create);  
            string mimeType = document.ContentType;
            //= new byte[product.File.Length];  

            BlobStorageService objBlobService = new BlobStorageService();

            return objBlobService.UploadFileToBlob(userId, fileData, mimeType,file);
        }

    }
}
