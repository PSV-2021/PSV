using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class specialityMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 20, 49, 57, 435, DateTimeKind.Local).AddTicks(9828));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 20, 49, 57, 440, DateTimeKind.Local).AddTicks(5283));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 20, 49, 57, 440, DateTimeKind.Local).AddTicks(5386));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 17, 6, 42, 905, DateTimeKind.Local).AddTicks(6593));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 17, 6, 42, 908, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 17, 6, 42, 908, DateTimeKind.Local).AddTicks(4984));
        }
    }
}
