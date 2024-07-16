using IMSBussinessObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public interface IDocumentsRepository
    {
        public Document GetDocumentById(int documentId);

        public List<Document> GetDocuments();

        public void DeleteDocument(int documentId);

        public void UploadDocumentAsync(IFormFile file, int internId);
    }
}
