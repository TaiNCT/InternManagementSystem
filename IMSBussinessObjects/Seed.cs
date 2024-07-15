using Microsoft.EntityFrameworkCore;

namespace IMSBussinessObjects
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)

        #region EmailTemplate
        {
            modelBuilder.Entity<EmailTemplate>().HasData(
            new EmailTemplate
            {
                Id = 1,
                Name = "Welcome_Email",
                Status = true,
                Body = "Chào mừng bạn đến với IMS! Kính gửi [Name], cảm ơn bạn đã tham gia cùng chúng tôi.",
                Params = "[Name]",
                Subject = "Welcome to IMS!",
                Description = "Email này được gửi để chào đón người dùng mới."
            },
            new EmailTemplate
            {
                Id = 2,
                Name = "Interview_Intern",
                Status = true,
                Body = "Dear [Name], Please manage your time to have an interview at: [InterviewDate], [InterviewPlace].",
                Params = "[Name], [InterviewDate], [InterviewPlace]",
                Subject = "Interview",
                Description = "Email này để gửi intern đi phỏng vấn."
            },
            new EmailTemplate
            {
                Id = 3,
                Name = "Interview_Supervisor",
                Status = true,
                Body = "Dear [SupervisorName], Please manage your time to interview: [InternName], at: [InterviewDate], [InterviewPlace].",
                Params = "[SupervisorName], [InternName], [InterviewDate], [InterviewPlace]",
                Subject = "Interview",
                Description = "Email này để gửi supervisor đi phỏng vấn intern."
            }
        );
        }
        #endregion
    }
}
