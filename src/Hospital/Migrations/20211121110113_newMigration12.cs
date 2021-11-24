using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class newMigration12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 12, 1, 12, 502, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 12, 1, 12, 505, DateTimeKind.Local).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 12, 1, 12, 506, DateTimeKind.Local).AddTicks(29));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 33, 0, 747, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 33, 0, 750, DateTimeKind.Local).AddTicks(8389));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 33, 0, 750, DateTimeKind.Local).AddTicks(8470));
        }
    }
}
