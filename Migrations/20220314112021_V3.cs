using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Rezervacije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SaloniKorisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalonId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaloniKorisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaloniKorisnici_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaloniKorisnici_Saloni_SalonId",
                        column: x => x.SalonId,
                        principalTable: "Saloni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_SalonId",
                table: "Rezervacije",
                column: "SalonId");

            migrationBuilder.CreateIndex(
                name: "IX_SaloniKorisnici_KorisnikId",
                table: "SaloniKorisnici",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_SaloniKorisnici_SalonId",
                table: "SaloniKorisnici",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Saloni_SalonId",
                table: "Rezervacije",
                column: "SalonId",
                principalTable: "Saloni",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Saloni_SalonId",
                table: "Rezervacije");

            migrationBuilder.DropTable(
                name: "SaloniKorisnici");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_SalonId",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Rezervacije");
        }
    }
}
