using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class migrationN2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "ApointmentDescription", "DoctorId", "DurationInMunutes", "IsDeleted", "PatientId", "StartTime", "SurveyId", "SurveyId1", "isCancelled" },
                values: new object[] { 1, "All good", 1, 0, false, 1, new DateTime(2021, 12, 7, 16, 30, 0, 0, DateTimeKind.Unspecified), 0, null, false });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuedTime",
                value: new DateTime(2021, 12, 12, 10, 18, 35, 216, DateTimeKind.Local).AddTicks(1523));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 12, 10, 18, 35, 197, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 12, 10, 18, 35, 205, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 12, 10, 18, 35, 205, DateTimeKind.Local).AddTicks(5979));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IssuedTime",
                value: new DateTime(2021, 12, 12, 10, 16, 1, 558, DateTimeKind.Local).AddTicks(3634));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 12, 10, 16, 1, 537, DateTimeKind.Local).AddTicks(5695));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 12, 10, 16, 1, 549, DateTimeKind.Local).AddTicks(9976));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 12, 10, 16, 1, 550, DateTimeKind.Local).AddTicks(162));
        }
    }
}
