using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Drugstore.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Medicines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Precautions",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reactions",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideEffects",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usage",
                table: "Medicines",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Medicines",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Name", "Password", "Role", "Username" },
                values: new object[] { 3, "Pharmacist", "Farmaceut", "farmaceut", "Pharmacist", "farmaceut" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Discriminator", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "User", "farmaceut", "pharmacist", "farmaceut" },
                    { 2, "User", "kupac", "customer", "kupac" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_MedicineId",
                table: "Medicines",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Medicines_MedicineId",
                table: "Medicines",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Medicines_MedicineId",
                table: "Medicines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_MedicineId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Precautions",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Reactions",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SideEffects",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Usage",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Medicines");
        }
    }
}
