using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class doctorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "WorkingHours",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "VacationDays",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AvailableDaysOff = table.Column<int>(type: "integer", nullable: false),
                    SpecialityId = table.Column<int>(type: "integer", nullable: false),
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
                    Type = table.Column<int>(type: "integer", nullable: false),
                    SalaryInRsd = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Adress", "AvailableDaysOff", "DateOfBirth", "Email", "Jmbg", "Name", "Password", "PhoneNumber", "SalaryInRsd", "Sex", "SpecialityId", "Surname", "Type", "Username" },
                values: new object[] { 1, "Bulevar Oslobodjenja 4", 20, new DateTime(1998, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "milan@gmail.com", "3009998805137", "Milan", "02145", "0641664608", 200000, 0, 1, "Popovic", 2, "miki56" });

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_DoctorId",
                table: "WorkingHours",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationDays_DoctorId",
                table: "VacationDays",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecialityId",
                table: "Doctors",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VacationDays_Doctors_DoctorId",
                table: "VacationDays",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Doctors_DoctorId",
                table: "WorkingHours",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VacationDays_Doctors_DoctorId",
                table: "VacationDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Doctors_DoctorId",
                table: "WorkingHours");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_DoctorId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_VacationDays_DoctorId",
                table: "VacationDays");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "VacationDays");

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 21, 21, 19, 446, DateTimeKind.Local).AddTicks(661));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 21, 21, 19, 449, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 17, 21, 21, 19, 449, DateTimeKind.Local).AddTicks(2802));
        }
    }
}
