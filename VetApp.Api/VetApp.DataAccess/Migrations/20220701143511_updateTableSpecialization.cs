using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Api.Migrations
{
    public partial class updateTableSpecialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specializations_Vets_VetId",
                table: "Specializations");

            migrationBuilder.DropIndex(
                name: "IX_Specializations_VetId",
                table: "Specializations");

            migrationBuilder.DropColumn(
                name: "VetId",
                table: "Specializations");

            migrationBuilder.CreateTable(
                name: "SpecializationVet",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "INTEGER", nullable: false),
                    VetsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationVet", x => new { x.SpecializationId, x.VetsId });
                    table.ForeignKey(
                        name: "FK_SpecializationVet_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationVet_Vets_VetsId",
                        column: x => x.VetsId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationVet_VetsId",
                table: "SpecializationVet",
                column: "VetsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializationVet");

            migrationBuilder.AddColumn<int>(
                name: "VetId",
                table: "Specializations",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_VetId",
                table: "Specializations",
                column: "VetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specializations_Vets_VetId",
                table: "Specializations",
                column: "VetId",
                principalTable: "Vets",
                principalColumn: "Id");
        }
    }
}
