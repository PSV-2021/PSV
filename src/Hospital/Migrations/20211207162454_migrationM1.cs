using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class migrationM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ApointmentDescription", "DoctorId", "DurationInMunutes", "IsDeleted", "PatientId", "StartTime" },
                values: new object[] { 1, "All good", 1, 0, false, 2, new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 7, 17, 24, 51, 618, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 7, 17, 24, 51, 631, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 7, 17, 24, 51, 631, DateTimeKind.Local).AddTicks(3721));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 7, 17, 15, 26, 434, DateTimeKind.Local).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 7, 17, 15, 26, 445, DateTimeKind.Local).AddTicks(2545));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 7, 17, 15, 26, 445, DateTimeKind.Local).AddTicks(2739));
        }
    }
}
