using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models{
    public class Termin{
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string VremeOd{get; set;}

        [Required]
        public string VremeDo{get; set;}

        [JsonIgnore]
        public List<RadnikTermin> RadniciTermini { get; set; }

    }
}