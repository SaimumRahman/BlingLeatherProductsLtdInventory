using BlingLeatherProductsLtd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlingLeatherProductsLtd.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<RawMaterials> RawMaterials { get; set; }
        public DbSet<RawMaterialsLocal> RawMaterialsLocal { get; set; }
        public DbSet<RawMaterialsDetails> RawMaterialsDetails { get; set; }
        public DbSet<RawMaterialsDetailsLocal> RawMaterialsDetailsLocal { get; set; }
        public DbSet<ChemicalMaterials> ChemicalMaterials { get; set; }
        public DbSet<ChemicalMaterialsDetails> ChemicalMaterialsDetails { get; set; } 
        public DbSet<Accessories> AccessoriesList{ get; set; } 
        public DbSet<RecievedAccessoriess> RecievedAccessories { get; set; }
        public DbSet<RequisitionAccessories> RequisitionAccessories { get; set; }
          
       
        
    }
}
