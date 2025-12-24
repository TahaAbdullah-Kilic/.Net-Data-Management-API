using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class PriorityTitleChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                column: "Title",
                value: "High");

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                column: "Title",
                value: "Low");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"),
                column: "Title",
                value: "Hard");

            migrationBuilder.UpdateData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"),
                column: "Title",
                value: "Easy");
        }
    }
}
