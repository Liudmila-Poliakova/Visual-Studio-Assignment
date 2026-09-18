// Data/ApplicationDbContext.cs
// Author: Liudmila Poliakova
// Academy of Learning College
// This class connects the application to the database using Entity Framework

using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor that accepts options and passes them to the base DbContext class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet represents the Insurees table in the database
        public DbSet<Insuree> Insurees { get; set; }
    }
}
