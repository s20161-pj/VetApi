using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Api.Migrations
{
    public partial class VetClinicRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vets_ClinicId",
                table: "Vets",
                column: "ClinicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vets_Clinics_ClinicId",
                table: "Vets",
                column: "ClinicId",
                principalTable: "Clinics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vets_Clinics_ClinicId",
                table: "Vets");

            migrationBuilder.DropTable(
                name: "Clinics");

            migrationBuilder.DropIndex(
                name: "IX_Vets_ClinicId",
                table: "Vets");
        }
    }
}
