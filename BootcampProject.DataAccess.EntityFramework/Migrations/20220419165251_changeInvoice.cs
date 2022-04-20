using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampProject.DataAccess.EntityFramework.Migrations
{
    public partial class changeInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingDate",
                schema: "BootcampProject",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Paid",
                schema: "BootcampProject",
                table: "Invoices");

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 370, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 372, DateTimeKind.Local).AddTicks(447));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 372, DateTimeKind.Local).AddTicks(464));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 373, DateTimeKind.Local).AddTicks(8906));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 373, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 373, DateTimeKind.Local).AddTicks(9213));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 373, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 376, DateTimeKind.Local).AddTicks(7730));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 376, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 376, DateTimeKind.Local).AddTicks(8043));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 19, 52, 51, 376, DateTimeKind.Local).AddTicks(8044));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BillingDate",
                schema: "BootcampProject",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                schema: "BootcampProject",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 500, DateTimeKind.Local).AddTicks(9890));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 502, DateTimeKind.Local).AddTicks(2510));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 502, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 503, DateTimeKind.Local).AddTicks(8872));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 503, DateTimeKind.Local).AddTicks(9197));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 503, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 503, DateTimeKind.Local).AddTicks(9204));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5291));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5616));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5623));
        }
    }
}
