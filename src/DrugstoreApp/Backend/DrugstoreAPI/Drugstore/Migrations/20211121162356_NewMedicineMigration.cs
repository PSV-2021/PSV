using Microsoft.EntityFrameworkCore.Migrations;

namespace Drugstore.Migrations
{
    public partial class NewMedicineMigration : Migration
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
                name: "Substances",
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
                name: "Substances",
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
