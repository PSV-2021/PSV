using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class migrationN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuedTime",
                value: new DateTime(2022, 1, 9, 15, 20, 2, 685, DateTimeKind.Local).AddTicks(6881));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2022, 1, 9, 15, 20, 2, 640, DateTimeKind.Local).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2022, 1, 9, 15, 20, 2, 659, DateTimeKind.Local).AddTicks(2349));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2022, 1, 9, 15, 20, 2, 659, DateTimeKind.Local).AddTicks(2576));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuedTime",
                value: new DateTime(2021, 12, 27, 12, 8, 46, 742, DateTimeKind.Local).AddTicks(7829));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 27, 12, 8, 46, 710, DateTimeKind.Local).AddTicks(9326));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 27, 12, 8, 46, 718, DateTimeKind.Local).AddTicks(4164));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 27, 12, 8, 46, 718, DateTimeKind.Local).AddTicks(4489));
        }
    }
}
