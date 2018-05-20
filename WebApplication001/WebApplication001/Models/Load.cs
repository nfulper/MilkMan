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
        public string FarmName { get; set; }
        public int Pounds { get; set; }
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        
    }
}
