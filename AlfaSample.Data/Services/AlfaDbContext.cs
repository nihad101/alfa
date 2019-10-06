using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaSample.Data.Migration;
using AlfaSample.Data.Models;

namespace AlfaSample.Data.Services
{
    public class AlfaDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().HasKey(table => new {
                table.InvoiceNumber,
                table.CompanyName
            });
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
    }
}
