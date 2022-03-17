using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models{
    public class Usluga{
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Naziv{get; set;}

        //[Required]
        //public int Cena{get; set;}  

        [JsonIgnore]
        public List<SalonUsluga> Saloni { get; set; }

        [JsonIgnore]
        public List<Radnik> Radnici { get; set; }

    }
}