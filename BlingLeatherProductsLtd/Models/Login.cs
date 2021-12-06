using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Models
{
    public class Login
    {
        [Key]
        public int StoreUserId{ get; set; }
        [Required]
        public String Email{ get; set; }
        [Required]
        public String Passwords{ get; set; }
        [Required]
        public String Type{ get; set; }
    }
}
