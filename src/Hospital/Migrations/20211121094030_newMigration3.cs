using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class newMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AllergenId",
                table: "MedicalRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 40, 29, 215, DateTimeKind.Local).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 40, 29, 218, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 40, 29, 218, DateTimeKind.Local).AddTicks(248));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllergenId",
                table: "MedicalRecords");

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 15, 20, 158, DateTimeKind.Local).AddTicks(6798));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 15, 20, 165, DateTimeKind.Local).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 10, 15, 20, 165, DateTimeKind.Local).AddTicks(2436));
        }
    }
}
