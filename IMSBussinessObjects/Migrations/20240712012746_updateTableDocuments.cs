using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSBussinessObjects.Migrations
{
    public partial class updateTableDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropIndex(
                name: "IX_Interns_UserId",
                table: "Interns");

            migrationBuilder.DropColumn(
                name: "DocumentUrl",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Interns",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<byte[]>(
                name: "DocumentData",
                table: "Documents",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Documents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Interns_UserId",
                table: "Interns",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Interns_UserId",
                table: "Interns");

            migrationBuilder.DropColumn(
                name: "DocumentData",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Documents");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Interns",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentName",
                table: "Documents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "DocumentUrl",
                table: "Documents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interns_UserId",
                table: "Interns",
                column: "UserId",
                unique: true);
        }
    }
}
