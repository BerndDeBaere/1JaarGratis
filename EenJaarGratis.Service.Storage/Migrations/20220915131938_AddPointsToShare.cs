using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1EenJaarGratis.Service.Storage.Migrations
{
    public partial class AddPointsToShare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsToShare",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointsToShare",
                table: "Questions");
        }
    }
}
