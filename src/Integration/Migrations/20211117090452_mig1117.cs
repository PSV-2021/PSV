using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class mig1117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 10, 4, 51, 411, DateTimeKind.Local).AddTicks(6764), new DateTime(2021, 11, 17, 10, 4, 51, 417, DateTimeKind.Local).AddTicks(1562) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 10, 4, 51, 417, DateTimeKind.Local).AddTicks(2513), new DateTime(2021, 11, 17, 10, 4, 51, 417, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 10, 4, 51, 417, DateTimeKind.Local).AddTicks(2566), new DateTime(2021, 11, 17, 10, 4, 51, 417, DateTimeKind.Local).AddTicks(2570) });
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
