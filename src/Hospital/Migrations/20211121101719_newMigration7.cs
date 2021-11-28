using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class newMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Ingridient_AllergenId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_AllergenId",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "AllergenId",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "MedicalRecords");

            migrationBuilder.RenameIndex(
                name: "IX_Ingridient_MedicalRecordId",
                table: "Ingridients",
                newName: "IX_Ingridients_MedicalRecordId");

         /*   migrationBuilder.AddPrimaryKey(
                name: "PK_Ingridients",
                table: "Ingridients",
                column: "Id");*/

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 17, 18, 65, DateTimeKind.Local).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 17, 18, 68, DateTimeKind.Local).AddTicks(8134));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 17, 18, 68, DateTimeKind.Local).AddTicks(8198));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridients_MedicalRecords_MedicalRecordId",
                table: "Ingridients",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridients_MedicalRecords_MedicalRecordId",
                table: "Ingridients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingridients",
                table: "Ingridients");

            migrationBuilder.AddColumn<int>(
                name: "AllergenId",
                table: "MedicalRecords",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "MedicalRecords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "MedicalRecordId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 13, 1, 434, DateTimeKind.Local).AddTicks(181));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 13, 1, 437, DateTimeKind.Local).AddTicks(130));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 21, 11, 13, 1, 437, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AllergenId",
                table: "MedicalRecords",
                column: "AllergenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridient_MedicalRecords_MedicalRecordId",
                table: "Ingridient",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Ingridient_AllergenId",
                table: "MedicalRecords",
                column: "AllergenId",
                principalTable: "Ingridient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
