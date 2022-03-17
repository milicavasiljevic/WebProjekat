using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models{
    public class Radnik{
        
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Ime{get; set;}

        [Required]
        public string Prezime{get; set;}

        [Required]
        [StringLength(13)]
        public string Jmbg{get; set;}

        [JsonIgnore]
        public Salon Salon{get; set;}

        public Usluga Usluga{get; set;}
        
        [JsonIgnore]
        public List<RadnikTermin> Termini{get; set;}

    }
}