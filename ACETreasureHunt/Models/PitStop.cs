using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ACETreasureHunt.Models
{
    public class PitStop
    {
        [Key]
        public int Id { get; set; }
                
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Pit-Stop Name")]
        public string PitStopName { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1,5)]
        public int PitStopNumber { get; set; }

        [Required]
        [Range(-90.000, 90.0000)]
        public double Latitude { get; set; }

        [Required]
        [Range(-180.000, 180.0000)]
        public double Longitude { get; set; }

        public int EventID { get; set; }
    }
}