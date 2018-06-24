using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi.Data
{
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext>options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }

    }
}
