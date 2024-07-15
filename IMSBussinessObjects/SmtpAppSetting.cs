namespace IMSBussinessObjects
{
    public class SmtpAppSetting
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public bool EnableSsl { get; set; }
        public string AppVerify { get; set; }
    }
}
