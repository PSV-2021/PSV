using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    public partial class SecondDrugstoreMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Supply",
                table: "Medicines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    HospitalName = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Response = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "HospitalName", "Response" },
                values: new object[,]
                {
                    { "aaa", "Lenka vrati zeton", "Health", "" },
                    { "bbb", "normalno", "Ime bolnice 223", "" },
                    { "ccc", "bla bla", "Ime bolnice 224", "" }
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "ApiKey", "Name", "Url" },
                values: new object[] { 1, "DrugStoreSecretKey", "Health", "http://localhost:5000" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Price", "Supply" },
                values: new object[] { 150.0, 150 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price", "Supply" },
                values: new object[] { "Paracetamol", 150.0, 10 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price", "Supply" },
                values: new object[] { "Palitreks", 150.0, 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropColumn(
                name: "Supply",
                table: "Medicines");

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Olynth", 180.0 });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Polinol", 670.0 });
        }
    }
}
