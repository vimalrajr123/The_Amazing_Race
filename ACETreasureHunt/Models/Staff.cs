using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ACETreasureHunt.Models
{
    public class Staff
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(-90.000, 90.0000)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180.000, 180.0000)]
        public double Longitude { get; set; }
        
        public int EventID { get; set; }
    }
}