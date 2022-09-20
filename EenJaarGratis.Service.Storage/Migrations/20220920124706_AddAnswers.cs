using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1EenJaarGratis.Service.Storage.Migrations
{
    public partial class AddAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Possibilities",
                table: "Questions",
                newName: "Answer3");

            migrationBuilder.AddColumn<string>(
                name: "Answer1",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Answer2",
                table: "Questions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswer",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Answer2",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Answer3",
                table: "Questions",
                newName: "Possibilities");
        }
    }
}
