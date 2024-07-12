using IMSBussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace IMSDaos
{
    public class UploadFileDAO
    {
        private readonly AppDbContext db = null;
        private static UploadFileDAO instance = null;

        public UploadFileDAO()
        {
            db = new AppDbContext();
        }

        public static UploadFileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UploadFileDAO();
                }
                return instance;
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
                    var objFiles = new Documents()
                    {
                        DocumentId = 0,
                        DocumentName = fileName.Split(new Char[] { '.' })[0],
                        DocumentType = fileExtension,
                        InternId = internId
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
        public void UploadInternAsync(IFormFile file, int internId)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var fileExtension = Path.GetExtension(fileName);
                    var objFiles = new Documents()
                    {
                        DocumentId = 0,
                        DocumentName = fileName.Split(new Char[] { '.' })[0],
                        DocumentType = fileExtension,
                        InternId = internId
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
