using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication001.Models
{
    public class Load
    {
        public int ID { get; set; }

        [Display(Name = "Farm Name")]
        [Required]
        public string FarmName { get; set; }

        [Range(1, 75000)]
        [Required]
        public int Pounds { get; set; }

        
        [Required]
        public DateTime Time { get; set; }
        
    }
}
