using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class patientMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingridients_MedicalRecods_MedicalRecordId",
                table: "Ingridients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecods",
                table: "MedicalRecods");

            migrationBuilder.RenameTable(
                name: "MedicalRecods",
                newName: "MedicalRecords");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecords",
                table: "MedicalRecords",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsBlocked = table.Column<bool>(type: "boolean", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    FathersName = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    MedicalRecordId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Adress = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Adress", "BloodType", "DateOfBirth", "DoctorId", "Email", "EmergencyContact", "FathersName", "IsActive", "IsBlocked", "Jmbg", "MedicalRecordId", "Name", "Password", "PhoneNumber", "Sex", "Surname", "Type", "Username" },
                values: new object[] { 1, "Bulevar Oslobodjenja 8", 1, new DateTime(1998, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "marko@gmail.com", null, "Petar", true, false, "3009998805138", 1, "Marko", "miki985", "0641664608", 0, "Markovic", 3, "miki98" });

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 18, 11, 44, 21, 667, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 18, 11, 44, 21, 670, DateTimeKind.Local).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 18, 11, 44, 21, 670, DateTimeKind.Local).AddTicks(6460));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordId",
                table: "Patients",
                column: "MedicalRecordId");

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

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalRecords",
                table: "MedicalRecords");

            migrationBuilder.RenameTable(
                name: "MedicalRecords",
                newName: "MedicalRecods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalRecods",
                table: "MedicalRecods",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ingridients_MedicalRecods_MedicalRecordId",
                table: "Ingridients",
                column: "MedicalRecordId",
                principalTable: "MedicalRecods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
