using IMSBussinessObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public interface IDocumentsService
    {
        public Documents GetDocumentById(int documentId);

        public List<Documents> GetDocuments();

        public void DeleteDocument(int documentId);

        public void UploadDocumentAsync(IFormFile file, int internId);
    }
}
