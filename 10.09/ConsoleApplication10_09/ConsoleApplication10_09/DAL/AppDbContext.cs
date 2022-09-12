using ConsoleApplication10_09.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10_09.DAL
{
    public class AppDbContext:DbContext
    {
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=ConsoleAppTask;integrated security=true;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(model =>
            {
                model.HasKey(prop => prop.Id);
                model.Property(prop => prop.Name).HasMaxLength(30).IsRequired(true);
                model.Property(prop => prop.Surname).HasMaxLength(30).IsRequired(true);   
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
