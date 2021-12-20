using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlingLeatherProductsLtd.Models
{
    public class Accessories
    {
        [Key]
        public int AID { get; set; }

        [Required]
        public string AName { get; set; }
        
        [Required]
        public string ATotalQuantity { get; set; }
        
        [Required]
        public string AUnit { get; set; }

    }
}
