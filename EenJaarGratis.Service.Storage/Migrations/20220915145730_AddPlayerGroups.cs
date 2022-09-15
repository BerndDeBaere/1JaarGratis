using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary1EenJaarGratis.Service.Storage.Migrations
{
    public partial class AddPlayerGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerQuestionGroup_QuestionGroup_QuestionGroupsId",
                table: "PlayerQuestionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGroup_Questions_QuestionId",
                table: "QuestionGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionGroup",
                table: "QuestionGroup");

            migrationBuilder.RenameTable(
                name: "QuestionGroup",
                newName: "QuestionGroups");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionGroup_QuestionId",
                table: "QuestionGroups",
                newName: "IX_QuestionGroups_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionGroups",
                table: "QuestionGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerQuestionGroup_QuestionGroups_QuestionGroupsId",
                table: "PlayerQuestionGroup",
                column: "QuestionGroupsId",
                principalTable: "QuestionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGroups_Questions_QuestionId",
                table: "QuestionGroups",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerQuestionGroup_QuestionGroups_QuestionGroupsId",
                table: "PlayerQuestionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionGroups_Questions_QuestionId",
                table: "QuestionGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionGroups",
                table: "QuestionGroups");

            migrationBuilder.RenameTable(
                name: "QuestionGroups",
                newName: "QuestionGroup");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionGroups_QuestionId",
                table: "QuestionGroup",
                newName: "IX_QuestionGroup_QuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionGroup",
                table: "QuestionGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerQuestionGroup_QuestionGroup_QuestionGroupsId",
                table: "PlayerQuestionGroup",
                column: "QuestionGroupsId",
                principalTable: "QuestionGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionGroup_Questions_QuestionId",
                table: "QuestionGroup",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
