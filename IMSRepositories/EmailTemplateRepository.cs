using IMSBussinessObjects;
using IMSDaos;

namespace IMSRepositories
{
    public class EmailTemplateRepository : IEmailTemplateRepository
    {
        public List<EmailTemplate> GetEmails() => EmailTemplateDao.Instance.GetAllEmail();
        public EmailTemplate GetEmailsByName(string emailName) => EmailTemplateDao.Instance.GetEmailByName(emailName);
    }
}
