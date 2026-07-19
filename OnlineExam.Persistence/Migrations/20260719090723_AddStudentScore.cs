using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ended",
                table: "Exams");

            migrationBuilder.AddColumn<decimal>(
                name: "StudentScore",
                table: "TrueOrFalseAnswers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalScore",
                table: "Questions",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StudentScore",
                table: "MultipleChoiceAnswers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StudentScore",
                table: "DescriptiveAnswers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentScore",
                table: "TrueOrFalseAnswers");

            migrationBuilder.DropColumn(
                name: "StudentScore",
                table: "MultipleChoiceAnswers");

            migrationBuilder.DropColumn(
                name: "StudentScore",
                table: "DescriptiveAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "TotalScore",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ended",
                table: "Exams",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
