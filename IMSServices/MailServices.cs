using IMSBussinessObjects;
using IMSRepositories;
using LinqKit;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
namespace IMSServices
{
    public class MailServices : IMailServices
    {
        private readonly SmtpAppSetting _smtpAppSetting;
        private readonly IEmailTemplateRepository _emailTemplateRepository;
        public MailServices(IEmailTemplateRepository emailTemplateRepository, IOptions<SmtpAppSetting> appSetting)
        {
            _emailTemplateRepository = emailTemplateRepository;
            _smtpAppSetting = appSetting.Value;
        }
        public async Task SendAsync(string name, List<string> toAddress, List<string> ccAddresses, Dictionary<string, string> param)
        {

            var list = _emailTemplateRepository.GetEmails();
            var template = _emailTemplateRepository.GetEmailsByName(name);
            if (template == null) return;

            await SendAsync(template, toAddress, ccAddresses, param);
        }


        private async Task SendAsync(EmailTemplate template, List<string> toAddress, List<string> ccAddresses, Dictionary<string, string> param)
        {
            var smtpAppSetting = new SmtpAppSetting // Assuming you have a class SmtpAppSetting with necessary properties
            {
                SmtpHost = _smtpAppSetting.SmtpHost,
                SmtpPort = _smtpAppSetting.SmtpPort,
                SmtpUserName = _smtpAppSetting.SmtpUserName, // Replace with your actual Email address
                SmtpPassword = _smtpAppSetting.SmtpPassword, // Replace with your actual app password
                AppVerify = _smtpAppSetting.AppVerify // Adjust as per your requirements
            };

            using (var client = new SmtpClient(smtpAppSetting.SmtpHost, smtpAppSetting.SmtpPort))
            {
                client.EnableSsl = _smtpAppSetting.EnableSsl;
                client.Credentials = new NetworkCredential(smtpAppSetting.SmtpUserName, smtpAppSetting.AppVerify);
                client.Port = smtpAppSetting.SmtpPort;

                using (var message = new MailMessage())
                {
                    try
                    {
                        message.From = new MailAddress(smtpAppSetting.SmtpUserName);

                        toAddress?.ForEach(to => message.To.Add(to));
                        ccAddresses?.ForEach(cc => message.CC.Add(cc));

                        message.Subject = ReplaceParam(template.Subject, param);
                        message.Body = ReplaceParam(template.Body, param);
                        message.IsBodyHtml = true;

                        message.BodyEncoding = System.Text.Encoding.UTF8;
                        message.SubjectEncoding = System.Text.Encoding.UTF8;

                        await client.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        throw new ApplicationException($"Failed to send Email: {ex.Message}", ex);
                    }
                }
            }
        }

        private static string ReplaceParam(string data, Dictionary<string, string> parameters)
        {
            parameters.ForEach(k => data = data.Replace($"[{k.Key}]", k.Value));
            return data;
        }


    }
}