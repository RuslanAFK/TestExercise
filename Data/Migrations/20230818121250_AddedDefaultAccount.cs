using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestExercise.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountName", "IncidentName" },
                values: new object[] { 1, "ruslan", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1);
        }
    }
}
