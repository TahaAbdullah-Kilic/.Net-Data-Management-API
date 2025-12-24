using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class TaskSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "PriorityId", "ProjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("16d791fc-688d-4568-a107-27671392d18d"), "Description for Alpha Task 4", new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"), new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "Alpha Task 4" },
                    { new Guid("1e7a6ab0-828b-473f-bb29-a2c80f510ece"), "Description for Beta Task 1", new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"), new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "Beta Task 1" },
                    { new Guid("4a2f1e9e-edaa-42bc-9387-649afa9cc936"), "Description for Alpha Task 1", new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"), new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "Alpha Task 1" },
                    { new Guid("4a61d1e9-226e-4e78-8e03-17ac17b8e74a"), "Description for Alpha Task 3", new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"), new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "Alpha Task 3" },
                    { new Guid("74e7c49d-0b01-4121-a45a-4555d0d2d6c3"), "Description for Beta Task 5", new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"), new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "Beta Task 5" },
                    { new Guid("99e2e800-7ee7-4fdc-a8b5-ed6f47f95ada"), "Description for Alpha Task 5", new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"), new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "Alpha Task 5" },
                    { new Guid("a3f9b849-d41c-49e9-bbc1-8f23df2e69dd"), "Description for Beta Task 4", new Guid("b45412d8-abc9-4355-aff7-a88f9cb52cab"), new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "Beta Task 4" },
                    { new Guid("a857d5c3-7608-4100-9f32-b1e0a099fba1"), "Description for Alpha Task 2", new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"), new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "Alpha Task 2" },
                    { new Guid("ace396b7-69bd-450b-97cd-da1aa5450914"), "Description for Beta Task 2", new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"), new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "Beta Task 2" },
                    { new Guid("d2f1c4e8-3b6a-4f5e-9f3e-1c2b3a4d5e6f"), "Create the initial database schema for the project.", new Guid("6878803a-19d8-45ac-b84e-5b0f68989132"), new Guid("073859b5-ae0c-4473-a156-435934ab5467"), "Design Database Schema" },
                    { new Guid("e3f2d5c6-4a7b-4c8d-9e0f-2a3b4c5d6e7f"), "Develop the authentication module for user login and registration.", new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"), new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "Implement Authentication" },
                    { new Guid("f8d002be-2f6a-4b55-a209-23e076ddfc8f"), "Description for Beta Task 3", new Guid("059b3efd-aa86-467f-a5fa-9f0b0195342f"), new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"), "Beta Task 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("16d791fc-688d-4568-a107-27671392d18d"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1e7a6ab0-828b-473f-bb29-a2c80f510ece"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4a2f1e9e-edaa-42bc-9387-649afa9cc936"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4a61d1e9-226e-4e78-8e03-17ac17b8e74a"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("74e7c49d-0b01-4121-a45a-4555d0d2d6c3"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("99e2e800-7ee7-4fdc-a8b5-ed6f47f95ada"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a3f9b849-d41c-49e9-bbc1-8f23df2e69dd"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a857d5c3-7608-4100-9f32-b1e0a099fba1"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ace396b7-69bd-450b-97cd-da1aa5450914"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d2f1c4e8-3b6a-4f5e-9f3e-1c2b3a4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e3f2d5c6-4a7b-4c8d-9e0f-2a3b4c5d6e7f"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f8d002be-2f6a-4b55-a209-23e076ddfc8f"));
        }
    }
}
