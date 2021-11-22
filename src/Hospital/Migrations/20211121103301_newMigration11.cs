using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class newMigration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridients_Patients_PatientId",
                table: "Ingridients");

            migrationBuilder.DropIndex(
                name: "IX_Ingridients_PatientId",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Ingridients");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Ingridients",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 30, 54, 394, DateTimeKind.Local).AddTicks(3774));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 30, 54, 397, DateTimeKind.Local).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 30, 54, 397, DateTimeKind.Local).AddTicks(8002));

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_PatientId",
                table: "Ingridients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridients_Patients_PatientId",
                table: "Ingridients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
