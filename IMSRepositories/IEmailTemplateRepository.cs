using IMSBussinessObjects;

namespace IMSRepositories
{
    public interface IEmailTemplateRepository
    {
        List<EmailTemplate> GetEmails();
        EmailTemplate GetEmailsByName(string emailName);
    }
}
