using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class newMigration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2021, 11, 21, 11, 28, 24, 25, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 28, 24, 28, DateTimeKind.Local).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 28, 24, 28, DateTimeKind.Local).AddTicks(2273));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2021, 11, 21, 11, 26, 27, 13, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 26, 27, 16, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 26, 27, 16, DateTimeKind.Local).AddTicks(5912));
        }
    }
}
