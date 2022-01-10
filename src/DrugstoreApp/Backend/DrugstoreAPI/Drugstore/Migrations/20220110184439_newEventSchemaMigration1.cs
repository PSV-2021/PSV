using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    public partial class newEventSchemaMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrugstoreEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    EventTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugstoreEvents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DrugstoreEvents",
                columns: new[] { "Id", "EventName", "EventTime" },
                values: new object[,]
                {
                    { 1, "Klik", new DateTime(2022, 1, 10, 19, 44, 39, 40, DateTimeKind.Local).AddTicks(3794) },
                    { 2, "Klik", new DateTime(2022, 1, 10, 19, 44, 39, 46, DateTimeKind.Local).AddTicks(6658) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrugstoreEvents");
        }
    }
}
