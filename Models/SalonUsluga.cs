using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models{
    public class SalonUsluga{
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        
        [JsonIgnore]
        public Salon Salon{get; set;}

        public Usluga Usluga{get; set;}

        public int Cena{get; set;}

    }
}