using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSBussinessObjects.Migrations
{
    public partial class updateCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "Chào mừng bạn đến với IMS! Kính gửi [Name], cảm ơn bạn đã tham gia cùng chúng tôi.", "Welcome to IMS!" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Params", "Status", "Subject" },
                values: new object[] { 2, "Dear [Name], Please manage your time to have an interview at: [InterviewDate], [InterviewPlace].", "Email này để gửi intern đi phỏng vấn.", "Interview_Intern", "[Name], [InterviewDate], [InterviewPlace]", true, "Interview" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Params", "Status", "Subject" },
                values: new object[] { 3, "Dear [SupervisorName], Please manage your time to interview: [InternName], at: [InterviewDate], [InterviewPlace].", "Email này để gửi supervisor đi phỏng vấn intern.", "Interview_Supervisor", "[SupervisorName], [InternName], [InterviewDate], [InterviewPlace]", true, "Interview" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "Chào mừng bạn đến với OnDemandTutor! Kính gửi [Name], cảm ơn bạn đã tham gia cùng chúng tôi.", "Welcome to OnDemandTutor!" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Params", "Status", "Subject" },
                values: new object[] { 5, "Kính gửi [Name], vui lòng nhấp vào liên kết để kích hoạt tài khoản của bạn: [ActivationLink].", "Email này chứa hướng dẫn để kích hoạt tài khoản người dùng.", "Account_Activation", "[Name], [ActivationLink]", true, "Account Activation" });
        }
    }
}
