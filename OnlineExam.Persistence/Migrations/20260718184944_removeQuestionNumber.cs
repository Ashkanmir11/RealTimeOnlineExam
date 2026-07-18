using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeQuestionNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionNumber",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionNumber",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
