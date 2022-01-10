using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations.EventDb
{
    public partial class NewMigrationEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventName = table.Column<string>(type: "text", nullable: true),
                    EventTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientEvents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PatientEvents",
                columns: new[] { "Id", "EventName", "EventTime" },
                values: new object[,]
                {
                    { 1, "Klik", new DateTime(2022, 1, 10, 21, 40, 24, 376, DateTimeKind.Local).AddTicks(4792) },
                    { 2, "Klik", new DateTime(2022, 1, 10, 21, 40, 24, 382, DateTimeKind.Local).AddTicks(1956) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientEvents");
        }
    }
}
