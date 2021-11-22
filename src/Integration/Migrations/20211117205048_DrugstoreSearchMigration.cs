using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class DrugstoreSearchMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 21, 50, 47, 182, DateTimeKind.Local).AddTicks(8521), new DateTime(2021, 11, 17, 21, 50, 47, 186, DateTimeKind.Local).AddTicks(2925) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 21, 50, 47, 186, DateTimeKind.Local).AddTicks(3693), new DateTime(2021, 11, 17, 21, 50, 47, 186, DateTimeKind.Local).AddTicks(3726) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 21, 50, 47, 186, DateTimeKind.Local).AddTicks(3739), new DateTime(2021, 11, 17, 21, 50, 47, 186, DateTimeKind.Local).AddTicks(3744) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 13, 16, 11, 37, 551, DateTimeKind.Local).AddTicks(5694), new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(1709) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2037), new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2062) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2074), new DateTime(2021, 11, 13, 16, 11, 37, 554, DateTimeKind.Local).AddTicks(2077) });
        }
    }
}
