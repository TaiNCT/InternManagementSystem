using Microsoft.EntityFrameworkCore;

namespace IMSBussinessObjects
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailTemplate>().HasData(
            new EmailTemplate
            {
                Id = 1,
                Name = "Welcome_Email",
                Status = true,
                Body = "Chào mừng bạn đến với OnDemandTutor! Kính gửi [Name], cảm ơn bạn đã tham gia cùng chúng tôi.",
                Params = "[Name]",
                Subject = "Welcome to OnDemandTutor!",
                Description = "Email này được gửi để chào đón người dùng mới."
            },
            new EmailTemplate
            {
                Id = 5,
                Name = "Account_Activation",
                Status = true,
                Body = "Kính gửi [Name], vui lòng nhấp vào liên kết để kích hoạt tài khoản của bạn: [ActivationLink].",
                Params = "[Name], [ActivationLink]",
                Subject = "Account Activation",
                Description = "Email này chứa hướng dẫn để kích hoạt tài khoản người dùng."
            }
        );
        }
    }
}
