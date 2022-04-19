using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampProject.DataAccess.EntityFramework.Migrations
{
    public partial class AddInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceType",
                schema: "BootcampProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "BootcampProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceTypeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceType_InvoiceTypeId",
                        column: x => x.InvoiceTypeId,
                        principalSchema: "BootcampProject",
                        principalTable: "InvoiceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserInvoices",
                schema: "BootcampProject",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserInvoices", x => new { x.UserId, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "BootcampProject",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationUserInvoices_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "BootcampProject",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                schema: "BootcampProject",
                table: "InvoiceType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5291), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Electric Bill", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5616), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Gas Bill", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5622), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Water Bill", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2022, 4, 19, 1, 1, 15, 507, DateTimeKind.Local).AddTicks(5623), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Dues", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserInvoices_InvoiceId",
                schema: "BootcampProject",
                table: "ApplicationUserInvoices",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceTypeId",
                schema: "BootcampProject",
                table: "Invoices",
                column: "InvoiceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserInvoices",
                schema: "BootcampProject");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "BootcampProject");

            migrationBuilder.DropTable(
                name: "InvoiceType",
                schema: "BootcampProject");

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 381, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 383, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 383, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 384, DateTimeKind.Local).AddTicks(8677));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 384, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 384, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 17, 18, 27, 20, 384, DateTimeKind.Local).AddTicks(8985));
        }
    }
}
