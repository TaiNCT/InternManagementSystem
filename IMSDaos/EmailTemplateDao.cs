using IMSBussinessObjects;

namespace IMSDaos
{
    public class EmailTemplateDao
    {
        private readonly AppDbContext db = null;
        private static EmailTemplateDao instance = null;

        public EmailTemplateDao()
        {
            db = new AppDbContext();
        }

        public static EmailTemplateDao Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmailTemplateDao();
                }
                return instance;
            }
        }


        public EmailTemplate GetEmailByName(string emailName)
        {
            return db.EmailTemplates.FirstOrDefault(x => x.Name == emailName);
        }



        public List<EmailTemplate> GetAllEmail()
        {
            return db.EmailTemplates.ToList();
        }

        //public void AddIntern(Intern intern)
        //{
        //    Intern newIntern = GetEmailById(intern.InternId);
        //    if (newIntern == null)
        //    {
        //        db.Interns.Add(intern);
        //        db.SaveChanges();
        //    }
        //}
    }
}
