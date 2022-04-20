using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampProject.DataAccess.EntityFramework.Migrations
{
    public partial class AddPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "BootcampProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 846, DateTimeKind.Local).AddTicks(8819));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 848, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 848, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 849, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 849, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 849, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 849, DateTimeKind.Local).AddTicks(8042));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 852, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 852, DateTimeKind.Local).AddTicks(7112));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 852, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 41, 14, 852, DateTimeKind.Local).AddTicks(7118));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments",
                schema: "BootcampProject");

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
    }
}
