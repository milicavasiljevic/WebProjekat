using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models{
    public class Salon{
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Naziv{get; set;}

        [Required]
        [MaxLength(50)]
        public string Adresa{get; set;}

        public List<Radnik> Radnici { get; set; }

        public List<SalonUsluga> Usluge {get; set;}

        public List<Rezervacija> Rezervacije{get; set;}

       // [JsonIgnore]
        //public List<Korisnik> Korisnici{get; set;}

    }
}