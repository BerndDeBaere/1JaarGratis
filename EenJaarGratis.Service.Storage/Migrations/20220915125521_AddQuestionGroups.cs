using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1EenJaarGratis.Service.Storage.Migrations
{
    public partial class AddQuestionGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionGroup_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerQuestionGroup",
                columns: table => new
                {
                    PlayersId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionGroupsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerQuestionGroup", x => new { x.PlayersId, x.QuestionGroupsId });
                    table.ForeignKey(
                        name: "FK_PlayerQuestionGroup_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerQuestionGroup_QuestionGroup_QuestionGroupsId",
                        column: x => x.QuestionGroupsId,
                        principalTable: "QuestionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerQuestionGroup_QuestionGroupsId",
                table: "PlayerQuestionGroup",
                column: "QuestionGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionGroup_QuestionId",
                table: "QuestionGroup",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerQuestionGroup");

            migrationBuilder.DropTable(
                name: "QuestionGroup");
        }
    }
}
