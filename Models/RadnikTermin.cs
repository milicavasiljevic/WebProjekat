using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace Models{


    public class RadnikTermin{

       // [JsonIgnore]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Datum{get; set;}

        //[JsonIgnore]
        public  Radnik Radnik { get; set; }
        
        public Termin Termin { get; set; }

        public bool Status {get; set;}
 
    }
}