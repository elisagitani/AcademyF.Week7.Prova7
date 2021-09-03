using AcademyF.Week7.Prova7.Core.Entities;
using AcademyF.Week7.Prova7.EF.Configuration;
using AcademyF.Week7.Prova7.EF.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week7.Prova7.EF.Context
{
    public class CommerceDbContext: DbContext
    {
        public CommerceDbContext()
            :base()
        {

        }

        public CommerceDbContext(DbContextOptions<CommerceDbContext> options)
            :base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Setting.GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}
