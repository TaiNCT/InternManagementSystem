using IMSServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternManagement.Pages.TestPage
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IDocumentsService documentsService;
        public IndexModel(ILogger<IndexModel> logger, IDocumentsService documentsSer)
        {
            this.logger = logger;
            this.documentsService = documentsSer;
        }
        public void OnGet()
        {
        }

    /*    public async void OnPostAsync(IFormFile file)
        {
            if (file != null)
            {
                documentsService.UploadDocumentAsync(file);
            }
        }*/
    }
}
