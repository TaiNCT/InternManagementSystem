using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSBussinessObjects.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Params = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Params", "Status", "Subject" },
                values: new object[] { 1, "Chào mừng bạn đến với OnDemandTutor! Kính gửi [Name], cảm ơn bạn đã tham gia cùng chúng tôi.", "Email này được gửi để chào đón người dùng mới.", "Welcome_Email", "[Name]", true, "Welcome to OnDemandTutor!" });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "Id", "Body", "Description", "Name", "Params", "Status", "Subject" },
                values: new object[] { 5, "Kính gửi [Name], vui lòng nhấp vào liên kết để kích hoạt tài khoản của bạn: [ActivationLink].", "Email này chứa hướng dẫn để kích hoạt tài khoản người dùng.", "Account_Activation", "[Name], [ActivationLink]", true, "Account Activation" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates");
        }
    }
}
