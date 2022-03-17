using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saloni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saloni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Termini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeOd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremeDo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termini", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jmbg = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: true),
                    UslugaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radnici_Saloni_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Saloni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Radnici_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaloniUsluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonId = table.Column<int>(type: "int", nullable: true),
                    UslugaId = table.Column<int>(type: "int", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaloniUsluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaloniUsluge_Saloni_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Saloni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaloniUsluge_Usluge_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Usluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadniciTermini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RadnikId = table.Column<int>(type: "int", nullable: true),
                    TerminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniciTermini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadniciTermini_Radnici_RadnikId",
                        column: x => x.RadnikId,
                        principalTable: "Radnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RadniciTermini_Termini_TerminId",
                        column: x => x.TerminId,
                        principalTable: "Termini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervisaniTerminId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_RadniciTermini_RezervisaniTerminId",
                        column: x => x.RezervisaniTerminId,
                        principalTable: "RadniciTermini",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_SalonId",
                table: "Radnici",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_Radnici_UslugaId",
                table: "Radnici",
                column: "UslugaId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniciTermini_RadnikId",
                table: "RadniciTermini",
                column: "RadnikId");

            migrationBuilder.CreateIndex(
                name: "IX_RadniciTermini_TerminId",
                table: "RadniciTermini",
                column: "TerminId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikId",
                table: "Rezervacije",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_RezervisaniTerminId",
                table: "Rezervacije",
                column: "RezervisaniTerminId");

            migrationBuilder.CreateIndex(
                name: "IX_SaloniUsluge_SalonId",
                table: "SaloniUsluge",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_SaloniUsluge_UslugaId",
                table: "SaloniUsluge",
                column: "UslugaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "SaloniUsluge");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "RadniciTermini");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "Termini");

            migrationBuilder.DropTable(
                name: "Saloni");

            migrationBuilder.DropTable(
                name: "Usluge");
        }
    }
}
