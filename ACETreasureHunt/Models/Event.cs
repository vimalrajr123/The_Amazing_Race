using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ACETreasureHunt.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Event Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        [Range(-90.000, 90.0000)]
        public double StartLatitude { get; set; }

        [Required]
        [Range(-180.000, 180.0000)]
        public double StartLongitude { get; set; }

        public string Address { get; set; }

       
        
    }
}