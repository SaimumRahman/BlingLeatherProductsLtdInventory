using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Models
{
    public class RecievedAccessoriess
    {
        [Key]
        public int ARID { get; set; }

        [Required]
        public int AID { get; set; }

        [Required]
        public String Date { get; set; }

        [Required]
        public String RecievedQnty { get; set; }

        [Required]
        public String OrderedQnty { get; set; }

        [Required]
        public String Invoices { get; set; }

        [Required]
        public String Remarks { get; set; }

      
    }
}
