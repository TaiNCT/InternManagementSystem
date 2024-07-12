using IMSServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.TestPage
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;    
        private readonly IUploadFileService uploadFileService;
        public IndexModel(ILogger<IndexModel> logger, IUploadFileService uploadFile)
        {
            this.logger = logger;
            this.uploadFileService = uploadFile;
        }
        public void OnGet()
        {
        }

        public async void  OnPostAsync(IFormFile file)
        {
            if (file != null)
            {
               uploadFileService.UploadDocumentAsync(file,1);
            }
        }
    }
}
