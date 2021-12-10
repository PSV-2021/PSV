using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class migrationM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SurveyId1",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 10, 11, 55, 8, 683, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 10, 11, 55, 8, 686, DateTimeKind.Local).AddTicks(6562));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 10, 11, 55, 8, 686, DateTimeKind.Local).AddTicks(6635));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SurveyId1",
                table: "Appointments",
                column: "SurveyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Survey_SurveyId1",
                table: "Appointments",
                column: "SurveyId1",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Survey_SurveyId1",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SurveyId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SurveyId1",
                table: "Appointments");

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 8, 10, 24, 58, 31, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 8, 10, 24, 58, 35, DateTimeKind.Local).AddTicks(1034));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 12, 8, 10, 24, 58, 35, DateTimeKind.Local).AddTicks(1114));
        }
    }
}
