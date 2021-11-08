using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class DrugstoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Drugstores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Drugstores",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 6, 2, 19, 10, 686, DateTimeKind.Local).AddTicks(7991), new DateTime(2021, 11, 6, 2, 19, 10, 689, DateTimeKind.Local).AddTicks(8405) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 6, 2, 19, 10, 689, DateTimeKind.Local).AddTicks(9143), new DateTime(2021, 11, 6, 2, 19, 10, 689, DateTimeKind.Local).AddTicks(9188) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 6, 2, 19, 10, 689, DateTimeKind.Local).AddTicks(9201), new DateTime(2021, 11, 6, 2, 19, 10, 689, DateTimeKind.Local).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Email" },
                values: new object[] { "Kneza 22", "apoteka1@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Email" },
                values: new object[] { "Kneza 23", "apoteka2@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Drugstores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Email" },
                values: new object[] { "Kneza 265", "apoteka3@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Drugstores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Drugstores");

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 4, 22, 46, 10, 39, DateTimeKind.Local).AddTicks(109), new DateTime(2021, 11, 4, 22, 46, 10, 41, DateTimeKind.Local).AddTicks(7334) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 4, 22, 46, 10, 41, DateTimeKind.Local).AddTicks(7732), new DateTime(2021, 11, 4, 22, 46, 10, 41, DateTimeKind.Local).AddTicks(7761) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 4, 22, 46, 10, 41, DateTimeKind.Local).AddTicks(7781), new DateTime(2021, 11, 4, 22, 46, 10, 41, DateTimeKind.Local).AddTicks(7785) });
        }
    }
}
