using AcademyF.Week7.Prova7.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week7.Prova7.EF.Configuration
{
    public class CustomerConfiguration: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.CustomerCode)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(c => c.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(c=>c.LastName)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
