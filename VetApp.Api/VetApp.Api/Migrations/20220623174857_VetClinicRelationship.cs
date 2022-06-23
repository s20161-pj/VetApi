using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Api.Migrations
{
    public partial class VetClinicRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinic", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vets_ClinicId",
                table: "Vets",
                column: "ClinicId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vets_Clinic_ClinicId",
                table: "Vets",
                column: "ClinicId",
                principalTable: "Clinic",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vets_Clinic_ClinicId",
                table: "Vets");

            migrationBuilder.DropTable(
                name: "Clinic");

            migrationBuilder.DropIndex(
                name: "IX_Vets_ClinicId",
                table: "Vets");
        }
    }
}
