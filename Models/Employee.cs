using System;  
using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations;  
using System.Linq;  
using System.Threading.Tasks;  
  
namespace MVCAdoDemo.Models  
{  
    public class Employee  
    {  
        public int ID { get; set; }  
        [Required]  
        public string name { get; set; }  
        [Required]  
        public string address { get; set; }  
        [Required]  
        public string department { get; set; }  
        [Required]  
        public string city { get; set; }  
        public double basic { get; set; }
        public double hra { get; set; }
        public double td { get; set; }
        public double da { get; set; }
        public double salary { get; set; }
    }  
}