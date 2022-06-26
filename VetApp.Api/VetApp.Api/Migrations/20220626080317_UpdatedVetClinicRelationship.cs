using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Api.Migrations
{
    public partial class UpdatedVetClinicRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clinics",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nip",
                table: "Clinics",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VeterinaryVisit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Class = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfVisit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeterinaryVisit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeterinaryVisit_Vets_VetId",
                        column: x => x.VetId,
                        principalTable: "Vets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeterinaryVisit_VetId",
                table: "VeterinaryVisit",
                column: "VetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VeterinaryVisit");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "Nip",
                table: "Clinics");
        }
    }
}
