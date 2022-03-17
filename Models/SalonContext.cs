using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class SalonContext: DbContext
    {
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<RadnikTermin> RadniciTermini { get; set; }
     
        public DbSet<Rezervacija> Rezervacije { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Termin> Termini{get; set;}
        public DbSet<Usluga> Usluge{get;set;}
        public DbSet<Salon> Saloni{get; set;}

        public DbSet<SalonUsluga> SaloniUsluge{get; set;}
        public SalonContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}