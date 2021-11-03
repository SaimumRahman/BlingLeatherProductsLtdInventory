﻿using BlingLeatherProductsLtd.Models;
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
        public DbSet<RawMaterialsDetails> RawMaterialsDetails { get; set; }
    }
}
