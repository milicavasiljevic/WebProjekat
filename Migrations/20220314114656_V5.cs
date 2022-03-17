using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaloniKorisnici");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Korisnici",
                newName: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Korisnici",
                newName: "email");

            migrationBuilder.CreateTable(
                name: "SaloniKorisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikId = table.Column<int>(type: "int", nullable: true),
                    SalonId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_SaloniKorisnici_KorisnikId",
                table: "SaloniKorisnici",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_SaloniKorisnici_SalonId",
                table: "SaloniKorisnici",
                column: "SalonId");
        }
    }
}
