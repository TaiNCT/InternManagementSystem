using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSBussinessObjects.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                collation: "SQL_Latin1_General_CP1_CS_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                collation: "SQL_Latin1_General_CP1_CS_AS",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Params" },
                values: new object[] { "Welcome IMS's Intenrship! Dear [Name], please enjoy your internship at team [Team].", "[Name], [Team]" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Params" },
                values: new object[] { "Dear [Name], Please manage your time to have an interview at: [InterviewDate], [InterviewPlace] at room [Room].", "[Name], [InterviewDate], [InterviewPlace], [Room]" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Params" },
                values: new object[] { "Dear [SupervisorName], Please manage your time to interview: [InternName], at: [InterviewDate], [InterviewPlace] room [Room].", "[SupervisorName], [InternName], [InterviewDate], [InterviewPlace], [Room]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldCollation: "SQL_Latin1_General_CP1_CS_AS");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Params" },
                values: new object[] { "Chào mừng bạn đến với IMS! Kính gửi [Name], cảm ơn bạn đã tham gia cùng chúng tôi.", "[Name]" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Body", "Params" },
                values: new object[] { "Dear [Name], Please manage your time to have an interview at: [InterviewDate], [InterviewPlace].", "[Name], [InterviewDate], [InterviewPlace]" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Body", "Params" },
                values: new object[] { "Dear [SupervisorName], Please manage your time to interview: [InternName], at: [InterviewDate], [InterviewPlace].", "[SupervisorName], [InternName], [InterviewDate], [InterviewPlace]" });
        }
    }
}
