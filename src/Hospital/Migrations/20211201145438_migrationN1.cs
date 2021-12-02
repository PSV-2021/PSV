using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class migrationN1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shift",
                table: "WorkingHours");

            migrationBuilder.AddColumn<int>(
                name: "WorkingHoursId",
                table: "Doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                column: "WorkingHoursId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "WorkingHoursId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 1, 15, 54, 36, 274, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 1, 15, 54, 36, 283, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 1, 15, 54, 36, 283, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WorkingHoursId",
                table: "Doctors",
                column: "WorkingHoursId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_WorkingHours_WorkingHoursId",
                table: "Doctors",
                column: "WorkingHoursId",
                principalTable: "WorkingHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_WorkingHours_WorkingHoursId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_WorkingHoursId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "WorkingHoursId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "Shift",
                table: "WorkingHours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 29, 17, 53, 35, 518, DateTimeKind.Local).AddTicks(6715));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 29, 17, 53, 35, 528, DateTimeKind.Local).AddTicks(5363));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 29, 17, 53, 35, 528, DateTimeKind.Local).AddTicks(5498));
        }
    }
}
