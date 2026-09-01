using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentIdToExamLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "ExamsLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "ExamsLogs");
        }
    }
}
