using IMSBussinessObjects;
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
        public Documents GetDocumentById(int documentId)
        {
            return db.Documents.FirstOrDefault(x => x.DocumentId == documentId);

        }
        public List<Documents> GetUsers()
        {
             return db.Documents.ToList();
        }
        public void DeleteDocument(int documentId)
        {
            Documents document = GetDocumentById(documentId);
            if (document != null)
            {
                db.Documents.Remove(document);
                db.SaveChanges();
            }
        }
    }
}
