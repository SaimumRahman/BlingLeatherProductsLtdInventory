using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Models
{
    public class RawMaterials
    {
        [Key]
        public int RMID { get; set; }
        [Required]

        public string HSCode { get; set; }
        [Required]
        public string BuyerName { get; set; }
        [Required]
        public string MaterialName { get; set; }
        [Required]
        public string BinNumber{ get; set; }
        [Required]
        public string ColorName { get; set; }
        [Required]
        public string ArticleNumber { get; set; }
        [Required]
        public string OrderedQuantity { get; set; }
        [Required]
        public string RecievedQuantity { get; set; }
        [Required]
        public string DateRecieved { get; set; } 
        public string BalancedQuantity { get; set; }


    }
}
