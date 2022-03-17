using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models{
    public class Rezervacija{

        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public Salon Salon{get; set;}

        public RadnikTermin RezervisaniTermin {get; set;} 
        //[JsonIgnore]
        public Korisnik Korisnik{get; set;}

    }
}