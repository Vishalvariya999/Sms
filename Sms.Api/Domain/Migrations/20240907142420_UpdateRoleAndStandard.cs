using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleAndStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Standard",
               columns: new[] { "StandardId", "StandardName", "Created", "CreatedBy", "Updated", "UpdatedBy", "Deleted" },
               values: new object[,]
               {
                    { 1, "Junior", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 2, "Senior", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 3, "1st", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 4, "2nd", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 5, "3rdd", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 6, "4th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 7, "5th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 8, "6th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 9, "7th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 10, "8th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 11, "9th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 12, "10th", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 13, "11th-Com", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 14, "12th-Com", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 15, "11th-Sci", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 16, "12th-Sci", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
               }
           );

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Name", "Created", "CreatedBy", "Updated", "UpdatedBy", "Deleted" },
                values: new object[,]
                {
                    { 1, "Ceo", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 2, "Principal", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 3, "Teacher", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                    { 4, "Peon", new DateTime(2024, 9, 7, 0, 0, 0), 1, new DateTime(2024, 9, 7, 0, 0, 0), 1, false },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
