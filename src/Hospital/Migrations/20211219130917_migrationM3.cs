using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class migrationM3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PatientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuedTime",
                value: new DateTime(2021, 12, 19, 14, 9, 14, 875, DateTimeKind.Local).AddTicks(386));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 19, 14, 9, 14, 853, DateTimeKind.Local).AddTicks(9154));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 19, 14, 9, 14, 861, DateTimeKind.Local).AddTicks(6766));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 19, 14, 9, 14, 861, DateTimeKind.Local).AddTicks(7210));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "PatientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuedTime",
                value: new DateTime(2021, 12, 19, 14, 7, 50, 778, DateTimeKind.Local).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 19, 14, 7, 50, 755, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 19, 14, 7, 50, 764, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 19, 14, 7, 50, 764, DateTimeKind.Local).AddTicks(415));
        }
    }
}
