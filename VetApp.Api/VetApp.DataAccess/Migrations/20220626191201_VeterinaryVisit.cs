using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Api.Migrations
{
    public partial class VeterinaryVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "VeterinaryVisit",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpeciesOfThePet = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    NameOfThePetOwner = table.Column<string>(type: "TEXT", nullable: false),
                    SurnameOfThePetOwner = table.Column<string>(type: "TEXT", nullable: false),
                    PetAddress = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VeterinaryVisit_ClientId",
                table: "VeterinaryVisit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ClientId",
                table: "Pets",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_VeterinaryVisit_Clients_ClientId",
                table: "VeterinaryVisit",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VeterinaryVisit_Clients_ClientId",
                table: "VeterinaryVisit");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_VeterinaryVisit_ClientId",
                table: "VeterinaryVisit");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "VeterinaryVisit");
        }
    }
}
