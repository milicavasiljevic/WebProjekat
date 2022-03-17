using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models{
    public class Korisnik{

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Ime{get; set;}

        [Required]
        public string Prezime{get; set;}

        [Required]
        public string Username{get; set;}

        [Required]
        [MinLength(8)]
        public string Sifra{get;set;}

        [JsonIgnore]
        public List<Rezervacija> Rezervacije{get; set;}

    }
}