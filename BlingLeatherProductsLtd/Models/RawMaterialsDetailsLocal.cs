using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Models
{
    public class RawMaterialsDetailsLocal
    {
        [Key]
        public int RMDIDL { get; set; }
        [Required]
        public int RMIDL { get; set; }
        [Required]
        public string Date { get; set; }   
        [Required]
        public string IssuedQuantity { get; set; }
        [Required]
        public string BalanceQuantity{ get; set; }
        [Required]
        public string RequisitionNumber { get; set; }
        [Required]
        public string SectionOrDepartment { get; set; }
        [Required]
        public string Remarks { get; set; }
        

    }
}
