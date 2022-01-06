using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveySystem.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyID = table.Column<int>(type: "int", nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilledBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurveyQuestionID = table.Column<int>(type: "int", nullable: true),
                    SurveyResponseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Question_SurveyQuestion_SurveyQuestionID",
                        column: x => x.SurveyQuestionID,
                        principalTable: "SurveyQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Question_SurveyResponse_SurveyResponseID",
                        column: x => x.SurveyResponseID,
                        principalTable: "SurveyResponse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Survey_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveySurveyQuestion",
                columns: table => new
                {
                    SurveyQuestionsID = table.Column<int>(type: "int", nullable: false),
                    SurveysID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveySurveyQuestion", x => new { x.SurveyQuestionsID, x.SurveysID });
                    table.ForeignKey(
                        name: "FK_SurveySurveyQuestion_Survey_SurveysID",
                        column: x => x.SurveysID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveySurveyQuestion_SurveyQuestion_SurveyQuestionsID",
                        column: x => x.SurveyQuestionsID,
                        principalTable: "SurveyQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveySurveyResponse",
                columns: table => new
                {
                    SurveyResponsesID = table.Column<int>(type: "int", nullable: false),
                    SurveysID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveySurveyResponse", x => new { x.SurveyResponsesID, x.SurveysID });
                    table.ForeignKey(
                        name: "FK_SurveySurveyResponse_Survey_SurveysID",
                        column: x => x.SurveysID,
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveySurveyResponse_SurveyResponse_SurveyResponsesID",
                        column: x => x.SurveyResponsesID,
                        principalTable: "SurveyResponse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyQuestionID",
                table: "Question",
                column: "SurveyQuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyResponseID",
                table: "Question",
                column: "SurveyResponseID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_QuestionID",
                table: "Survey",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySurveyQuestion_SurveysID",
                table: "SurveySurveyQuestion",
                column: "SurveysID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveySurveyResponse_SurveysID",
                table: "SurveySurveyResponse",
                column: "SurveysID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveySurveyQuestion");

            migrationBuilder.DropTable(
                name: "SurveySurveyResponse");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "SurveyQuestion");

            migrationBuilder.DropTable(
                name: "SurveyResponse");
        }
    }
}
