using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ildiko_Antal.Migrations
{
    public partial class InnitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adapost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    denumireadapost = table.Column<string>(maxLength: 30, nullable: false),
                    adresaadapost = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adapost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Specie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    denumirespecie = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Animale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nume = table.Column<string>(maxLength: 30, nullable: false),
                    regim = table.Column<string>(maxLength: 30, nullable: false),
                    altedetalii = table.Column<string>(maxLength: 30, nullable: false),
                    checkin = table.Column<DateTime>(nullable: false),
                    SpecieID = table.Column<int>(nullable: false),
                    AdapostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Animale_Adapost_AdapostID",
                        column: x => x.AdapostID,
                        principalTable: "Adapost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animale_Specie_SpecieID",
                        column: x => x.SpecieID,
                        principalTable: "Specie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animale_AdapostID",
                table: "Animale",
                column: "AdapostID");

            migrationBuilder.CreateIndex(
                name: "IX_Animale_SpecieID",
                table: "Animale",
                column: "SpecieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animale");

            migrationBuilder.DropTable(
                name: "Adapost");

            migrationBuilder.DropTable(
                name: "Specie");
        }
    }
}
