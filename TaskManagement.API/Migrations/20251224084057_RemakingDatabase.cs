using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class RemakingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedTimeInHours",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedTimeInHours",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("8f3a2c91-6b7e-4f5c-9a12-1d3e5b7c9a21"), "An e-commerce infrastructure covering product, order, and inventory management.", "E-Commerce Management System" },
                    { new Guid("b1a7f3e2-4c8a-4e0a-9d3f-1b2c3d4e5f60"), "Digital management of employee, leave, performance, and payroll processes.", "Human Resources Management System" },
                    { new Guid("c1e47b62-2d94-4a88-bf73-9e6a41d0f5bc"), "Redevelopment of the company’s existing website with a modern UI and performance-focused approach.", "Corporate Website Redesign" },
                    { new Guid("c2d4e6f8-1a3b-4c5d-9e7f-8a9b0c1d2e34"), "Real-time monitoring of warehouse movements and inventory levels.", "Inventory and Warehouse Tracking Application" },
                    { new Guid("e9f1a2b3-4c5d-6e7f-8a9b-0c1d2e3f4a56"), "Tracking and reporting customer requests using a ticket-based workflow.", "Customer Support and Ticketing System" },
                    { new Guid("f0123456-789a-4bcd-8e9f-0123456789ab"), "Centralized management of income, expenses, invoices, and payment processes.", "Finance and Invoice Tracking System" }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("16d791fc-688d-4568-a107-27671392d18d"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("1e7a6ab0-828b-473f-bb29-a2c80f510ece"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4a2f1e9e-edaa-42bc-9387-649afa9cc936"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("4a61d1e9-226e-4e78-8e03-17ac17b8e74a"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("74e7c49d-0b01-4121-a45a-4555d0d2d6c3"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("99e2e800-7ee7-4fdc-a8b5-ed6f47f95ada"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a3f9b849-d41c-49e9-bbc1-8f23df2e69dd"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a857d5c3-7608-4100-9f32-b1e0a099fba1"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("ace396b7-69bd-450b-97cd-da1aa5450914"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("d2f1c4e8-3b6a-4f5e-9f3e-1c2b3a4d5e6f"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("e3f2d5c6-4a7b-4c8d-9e0f-2a3b4c5d6e7f"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("f8d002be-2f6a-4b55-a209-23e076ddfc8f"),
                column: "EstimatedTimeInHours",
                value: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("8f3a2c91-6b7e-4f5c-9a12-1d3e5b7c9a21"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("b1a7f3e2-4c8a-4e0a-9d3f-1b2c3d4e5f60"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c1e47b62-2d94-4a88-bf73-9e6a41d0f5bc"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("c2d4e6f8-1a3b-4c5d-9e7f-8a9b0c1d2e34"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("e9f1a2b3-4c5d-6e7f-8a9b-0c1d2e3f4a56"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("f0123456-789a-4bcd-8e9f-0123456789ab"));

            migrationBuilder.DropColumn(
                name: "EstimatedTimeInHours",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedTimeInHours",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("073859b5-ae0c-4473-a156-435934ab5467"),
                column: "EstimatedTimeInHours",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("69335471-cbd2-405a-b0bc-1cf94ba6aa0e"),
                column: "EstimatedTimeInHours",
                value: 150);
        }
    }
}
