using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations
{
    public partial class medicines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Supply = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "aaa",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 18, 28, 22, 989, DateTimeKind.Local).AddTicks(807), new DateTime(2021, 11, 17, 18, 28, 22, 993, DateTimeKind.Local).AddTicks(5745) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "bbb",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 18, 28, 22, 993, DateTimeKind.Local).AddTicks(6846), new DateTime(2021, 11, 17, 18, 28, 22, 993, DateTimeKind.Local).AddTicks(6910) });

            migrationBuilder.UpdateData(
                table: "DrugstoreFeedbacks",
                keyColumn: "Id",
                keyValue: "ccc",
                columns: new[] { "RecievedTime", "SentTime" },
                values: new object[] { new DateTime(2021, 11, 17, 18, 28, 22, 993, DateTimeKind.Local).AddTicks(6944), new DateTime(2021, 11, 17, 18, 28, 22, 993, DateTimeKind.Local).AddTicks(6959) });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "Id", "Name", "Supply" },
                values: new object[,]
                {
                    { 1, "Brufen", 0 },
                    { 2, "Paracetamol", 0 },
                    { 3, "Palitreks", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicines");

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
    }
}
