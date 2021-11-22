using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class medicalRecordMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "Ingridients",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicalRecods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HealthInsuranceNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MedicalRecods",
                columns: new[] { "Id", "HealthInsuranceNumber" },
                values: new object[] { 1, "1ab" });

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 18, 11, 38, 10, 264, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 18, 11, 38, 10, 267, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 18, 11, 38, 10, 267, DateTimeKind.Local).AddTicks(9303));

            migrationBuilder.CreateIndex(
                name: "IX_Ingridients_MedicalRecordId",
                table: "Ingridients",
                column: "MedicalRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridients_MedicalRecods_MedicalRecordId",
                table: "Ingridients",
                column: "MedicalRecordId",
                principalTable: "MedicalRecods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridients_MedicalRecods_MedicalRecordId",
                table: "Ingridients");

            migrationBuilder.DropTable(
                name: "MedicalRecods");

            migrationBuilder.DropIndex(
                name: "IX_Ingridients_MedicalRecordId",
                table: "Ingridients");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Ingridients");

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 22, 18, 6, 615, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 22, 18, 6, 618, DateTimeKind.Local).AddTicks(2459));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 22, 18, 6, 618, DateTimeKind.Local).AddTicks(2531));
        }
    }
}
