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
                Body = "Welcome IMS's Intenrship! Dear [Name], please enjoy your internship at team [Team].",
                Params = "[Name], [Team]",
                Subject = "Welcome to IMS!",
                Description = "Email này được gửi để chào đón người dùng mới."
            },
            new EmailTemplate
            {
                Id = 2,
                Name = "Interview_Intern",
                Status = true,
                Body = "Dear [Name], Please manage your time to have an interview at: [InterviewDate], [InterviewPlace] at room [Room].",
                Params = "[Name], [InterviewDate], [InterviewPlace], [Room]",
                Subject = "Interview",
                Description = "Email này để gửi intern đi phỏng vấn."
            },
            new EmailTemplate
            {
                Id = 3,
                Name = "Interview_Supervisor",
                Status = true,
                Body = "Dear [SupervisorName], Please manage your time to interview: [InternName], at: [InterviewDate], [InterviewPlace] room [Room].",
                Params = "[SupervisorName], [InternName], [InterviewDate], [InterviewPlace], [Room]",
                Subject = "Interview",
                Description = "Email này để gửi supervisor đi phỏng vấn intern."
            }
        );
        }
        #endregion
    }
}
