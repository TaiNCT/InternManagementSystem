using IMSBussinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSDaos
{
    public class DocumentDAO
    {
        private readonly AppDbContext db = null;
        private static DocumentDAO instance = null;

        public DocumentDAO()
        {
            db = new AppDbContext();
        }
        public static DocumentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DocumentDAO();
                }
                return instance;
            }
        }
        public Document GetDocumentById(int documentId)
        {
            return db.Documents.FirstOrDefault(x => x.DocumentId == documentId);

        }
        public List<Document> GetDocuments()
        {
             return db.Documents.ToList();
        }
        public void DeleteDocument(int documentId)
        {
            Document document = GetDocumentById(documentId);
            if (document != null)
            {
                db.Documents.Remove(document);
                db.SaveChanges();
            }
        }
        public void UploadDocumentAsync(IFormFile file, int internId)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var objFiles = new Document()
                    {
                        DocumentId = 0,
                        DocumentName = fileName.Split(new Char[] { '.' })[0],
                        DocumentType = fileExtension,
                    };
                    using (var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        objFiles.DocumentData = target.ToArray();
                    }
                    db.Documents.Add(objFiles);
                    db.SaveChanges();
                }
            }
        }
    }
}
