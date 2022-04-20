using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BootcampProject.DataAccess.EntityFramework.Migrations
{
    public partial class AddPayment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 446, DateTimeKind.Local).AddTicks(4078));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 447, DateTimeKind.Local).AddTicks(5253));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "Blocks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 447, DateTimeKind.Local).AddTicks(5269));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 449, DateTimeKind.Local).AddTicks(2509));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 449, DateTimeKind.Local).AddTicks(2836));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 449, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "FlatTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 449, DateTimeKind.Local).AddTicks(2843));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 452, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 452, DateTimeKind.Local).AddTicks(3816));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 452, DateTimeKind.Local).AddTicks(3821));

            migrationBuilder.UpdateData(
                schema: "BootcampProject",
                table: "InvoiceType",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 19, 22, 48, 58, 452, DateTimeKind.Local).AddTicks(3822));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
