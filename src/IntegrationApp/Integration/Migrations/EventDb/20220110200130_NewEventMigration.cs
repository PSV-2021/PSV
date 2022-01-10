using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Integration.Migrations.EventDb
{
    public partial class NewEventMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegrationEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    EventTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationEvents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IntegrationEvents",
                columns: new[] { "Id", "EventName", "EventTime" },
                values: new object[,]
                {
                    { 1, "Klik", new DateTime(2022, 1, 10, 21, 1, 29, 817, DateTimeKind.Local).AddTicks(9973) },
                    { 2, "Klik", new DateTime(2022, 1, 10, 21, 1, 29, 824, DateTimeKind.Local).AddTicks(2984) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationEvents");
        }
    }
}
