using Demo.DaL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DaL.DataContext
{
    public class CompanyDataContext : DbContext
    {
        public CompanyDataContext(DbContextOptions<CompanyDataContext> options) : base(options)
        {
        }

        public DbSet<Deparntment> Deparntments { get; set; }
        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Deparntment>().HasMany(e => e.Employees).WithOne(E => E.Deparntment).HasForeignKey(FK => FK.DeparntmentId).IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }

    }
}
