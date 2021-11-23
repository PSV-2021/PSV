using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class sixMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyQuestion_Survey_SurveyId",
                table: "SurveyQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SurveyQuestion_SurveyId",
                table: "SurveyQuestion");

            migrationBuilder.DeleteData(
                table: "Survey",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "SurveyQuestion");

            migrationBuilder.AddColumn<List<int>>(
                name: "SurveyAnswers",
                table: "Survey",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "SurveyQuestions",
                table: "Survey",
                type: "integer[]",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 20, 14, 12, 19, 307, DateTimeKind.Local).AddTicks(4420));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 20, 14, 12, 19, 318, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 20, 14, 12, 19, 318, DateTimeKind.Local).AddTicks(7895));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurveyAnswers",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "SurveyQuestions",
                table: "Survey");

            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "SurveyQuestion",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "Id", "AppointmentId", "Date", "PatientId" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 16, 19, 4, 21, 227, DateTimeKind.Local).AddTicks(8175), 1 });

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 16, 19, 4, 21, 216, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 16, 19, 4, 21, 225, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 16, 19, 4, 21, 225, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_SurveyId",
                table: "SurveyQuestion",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyQuestion_Survey_SurveyId",
                table: "SurveyQuestion",
                column: "SurveyId",
                principalTable: "Survey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
