using IMSBussinessObjects;
using IMSDaos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSRepositories
{
    public class DocumentsRepository : IDocumentsRepository
    {
        public void DeleteDocument(int documentId) => DocumentDAO.Instance.DeleteDocument(documentId);

        public Documents GetDocumentById(int documentId) => DocumentDAO.Instance.GetDocumentById(documentId);
        public List<Documents> GetDocuments() => DocumentDAO.Instance.GetDocuments();

        public void UploadDocumentAsync(IFormFile file, int internId) => DocumentDAO.Instance.UploadDocumentAsync(file, internId);
    }
}
