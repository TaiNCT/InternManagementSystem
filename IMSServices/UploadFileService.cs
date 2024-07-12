
using IMSBussinessObjects;
using IMSDaos;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata;

namespace IMSServices
{
    public class UploadFileService : IUploadFileService
    {
        public void UploadDocumentAsync(IFormFile file, int internId) => UploadFileDAO.Instance.UploadDocumentAsync(file, internId);
        
    }
}
