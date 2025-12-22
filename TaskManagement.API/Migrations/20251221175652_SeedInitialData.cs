using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"), "Hard" },
                    { new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"), "Medium" },
                    { new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EstimatedTimeInHours", "Title" },
                values: new object[,]
                {
                    { new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "This is the first project.", 100, "Project Alpha" },
                    { new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "This is the second project.", 150, "Project Beta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"));

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"));

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("073859b5-ae0c-4473-a156-435934ab5467"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"));
        }
    }
}
