using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace book_note_app.Migrations
{
    /// <inheritdoc />
    public partial class AddResultColumnAtTableActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Activities");
        }
    }
}
