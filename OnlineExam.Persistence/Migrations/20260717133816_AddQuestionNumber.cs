using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuestionNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "TrueOrFalseQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "MultipleChoiceQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "DescriptiveQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "TrueOrFalseQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "MultipleChoiceQuestions");

            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "DescriptiveQuestions");
        }
    }
}
