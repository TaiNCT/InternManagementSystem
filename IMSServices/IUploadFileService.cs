using Microsoft.AspNetCore.Http;

namespace IMSServices
{
    public interface IUploadFileService
    {
        public void UploadDocumentAsync(IFormFile file, int internId);
    }
}
