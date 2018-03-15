using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ArtProducts.Data.Entities;

namespace ArtProducts.Data
{
    public class DutchContext : IdentityDbContext<StoreUser>
    {
        public DutchContext(DbContextOptions<DutchContext> options): base(options) //need to set up this constructor to accept this DbContectOptions
        {                                                                          //this is the way that connectionString is being passed into the 'context'
        }                                                                          //when the context is being added, taking options specified in Startup and passing them into the context so it knows which connection string to use

        public DbSet<Product> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        //because orders has a relationship with OrderItems, its optional to create a DbSet for OrderItem
    }
}
