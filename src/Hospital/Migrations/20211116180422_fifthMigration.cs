using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Hospital.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    QuestionType = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyQuestion_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Survey",
                columns: new[] { "Id", "AppointmentId", "Date", "PatientId" },
                values: new object[] { 1, 1, new DateTime(2021, 11, 16, 19, 4, 21, 227, DateTimeKind.Local).AddTicks(8175), 1 });

            migrationBuilder.InsertData(
                table: "SurveyQuestion",
                columns: new[] { "Id", "QuestionType", "Rating", "SurveyId", "Text" },
                values: new object[,]
                {
                    { 14, 2, 0, null, "How likely are you to recommend our hospital to a friend or family member?" },
                    { 13, 2, 0, null, "Do you feel that our work hours are well suited to treat you?" },
                    { 12, 2, 0, null, "How satisfied were you with the co-ordination between different departments?" },
                    { 11, 2, 0, null, "How would you rate the professionalism of our staff?" },
                    { 10, 2, 0, null, "How satisfied are you with the cleanliness and appearance of our hospital?" },
                    { 9, 2, 0, null, "How easy was it to schedule an appointment with our hospital?" },
                    { 8, 1, 0, null, "During this hospital stay, did nurses explain things in a way you could understand?" },
                    { 6, 1, 0, null, "During this hospital stay, did nurses treat you with courtesy and respect?" },
                    { 5, 0, 0, null, "During this hospital stay, did doctor explain things in a way you could understand?" },
                    { 4, 0, 0, null, "During this hospital stay, did doctor listen carefully to you?" },
                    { 3, 0, 0, null, "During this hospital stay, did doctor treat you with courtesy and respect?" },
                    { 2, 0, 0, null, "How satisfied were you with the time that your doctor spent with you?" },
                    { 1, 0, 0, null, "How satisfied are you with the work of your doctor?" },
                    { 7, 1, 0, null, "During this hospital stay, did nurses listen carefully to you?" }
                });

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 16, 19, 4, 21, 216, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 16, 19, 4, 21, 225, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 16, 19, 4, 21, 225, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.CreateIndex(
                name: "IX_SurveyQuestion_SurveyId",
                table: "SurveyQuestion",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyQuestion");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 4, 15, 17, 0, 975, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 4, 15, 17, 0, 978, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "UserFeedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "TimeWritten",
                value: new DateTime(2021, 11, 4, 15, 17, 0, 978, DateTimeKind.Local).AddTicks(8356));
        }
    }
}
