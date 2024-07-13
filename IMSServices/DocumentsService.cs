using IMSBussinessObjects;
using IMSRepositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSServices
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IDocumentsRepository _documentsRepository;
        public DocumentsService(IDocumentsRepository documentsRepository)
        {
            _documentsRepository = documentsRepository;
        }
        public void DeleteDocument(int documentId)
        {
            _documentsRepository.DeleteDocument(documentId);
        }

        public Documents GetDocumentById(int documentId)
        {
            return _documentsRepository.GetDocumentById(documentId);
        }

        public List<Documents> GetDocuments()
        {
            return _documentsRepository.GetDocuments();
        }

        public void UploadDocumentAsync(IFormFile file, int internId)
        {
            _documentsRepository.UploadDocumentAsync(file, internId);
        }
    }
}
