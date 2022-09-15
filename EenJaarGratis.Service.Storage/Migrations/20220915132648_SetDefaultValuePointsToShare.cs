using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1EenJaarGratis.Service.Storage.Migrations
{
    public partial class SetDefaultValuePointsToShare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PointsToShare",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 100,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PointsToShare",
                table: "Questions",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldDefaultValue: 100);
        }
    }
}
