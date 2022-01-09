using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Drugstore.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 14, 3, 47, 56, 286, DateTimeKind.Local).AddTicks(4861), new DateTime(2021, 12, 14, 3, 47, 56, 279, DateTimeKind.Local).AddTicks(7107) });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Posted", "Title" },
                values: new object[] { "Aloaloalo", new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbuna" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Posted", "Title" },
                values: new object[] { "Stigli su novi lekovi", new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novi lekovi" });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Content", "Posted", "Recipients", "Title" },
                values: new object[] { 3, "Obavestenje o promeni cena", new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vazno obavestenje" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 14, 2, 39, 2, 792, DateTimeKind.Local).AddTicks(294), new DateTime(2021, 12, 14, 2, 39, 2, 786, DateTimeKind.Local).AddTicks(6423) });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "Posted", "Title" },
                values: new object[] { "Stigao je novi lek", new DateTime(2021, 12, 14, 2, 39, 2, 792, DateTimeKind.Local).AddTicks(5265), "Novi lek" });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "Posted", "Title" },
                values: new object[] { "Uzbuna ale ale", new DateTime(2021, 12, 14, 2, 39, 2, 792, DateTimeKind.Local).AddTicks(7150), "Notifikacija za sve" });
        }
    }
}
