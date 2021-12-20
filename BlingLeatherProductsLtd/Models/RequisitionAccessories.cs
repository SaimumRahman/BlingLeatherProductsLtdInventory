using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Models
{
    public class RequisitionAccessories
    {

        [Key]
        public int RAID { get; set; }

        [Required]
        public int AID { get; set; }

        [Required]
        public String Date { get; set; }

        [Required]
        public String IssuedQnty { get; set; }

        [Required]
        public String RequisitionNo { get; set; }

        [Required]
        public String Section { get; set; }

        [Required]
        public String Remarks { get; set; }

    }
}
