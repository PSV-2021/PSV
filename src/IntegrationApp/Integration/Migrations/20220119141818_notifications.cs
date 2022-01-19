using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class notifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Posted = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Recipients = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "1",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 5, 15, 18, 17, 647, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "2",
                column: "TenderEnd",
                value: new DateTime(2022, 2, 9, 15, 18, 17, 656, DateTimeKind.Local).AddTicks(7089));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "3",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 12, 15, 18, 17, 656, DateTimeKind.Local).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "4",
                column: "TenderEnd",
                value: new DateTime(2021, 12, 22, 15, 18, 17, 656, DateTimeKind.Local).AddTicks(7295));

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "Posted", "Recipients", "Title" },
                values: new object[,]
                {
                    { 1, "Aloaloalo", new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Uzbuna" },
                    { 2, "Stigli su novi lekovi", new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Novi lekovi" },
                    { 3, "Obavestenje o promeni cena", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vazno obavestenje" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "1",
                column: "TenderEnd",
                value: new DateTime(2021, 12, 29, 13, 48, 22, 725, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "2",
                column: "TenderEnd",
                value: new DateTime(2022, 2, 2, 13, 48, 22, 727, DateTimeKind.Local).AddTicks(843));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "3",
                column: "TenderEnd",
                value: new DateTime(2022, 1, 5, 13, 48, 22, 727, DateTimeKind.Local).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "DrugTenders",
                keyColumn: "Id",
                keyValue: "4",
                column: "TenderEnd",
                value: new DateTime(2021, 12, 15, 13, 48, 22, 727, DateTimeKind.Local).AddTicks(922));
        }
    }
}
