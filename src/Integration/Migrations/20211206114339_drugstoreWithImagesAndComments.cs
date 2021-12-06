using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Integration.Migrations
{
    public partial class drugstoreWithImagesAndComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base64Image",
                table: "Drugstores",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Drugstores",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 6, 12, 43, 38, 523, DateTimeKind.Local).AddTicks(9754), new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(4997) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(5327), new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(5353) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(5363), new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(5367) });

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(5888), new DateTime(2021, 12, 6, 12, 43, 38, 527, DateTimeKind.Local).AddTicks(5880) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Image",
                table: "Drugstores");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Drugstores");

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 24, 17, 8, 57, 863, DateTimeKind.Local).AddTicks(4790), new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(1767) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(2581), new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(2629), new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "DrugstoreOffers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(3344), new DateTime(2021, 11, 24, 17, 8, 57, 871, DateTimeKind.Local).AddTicks(3336) });
        }
    }
}
