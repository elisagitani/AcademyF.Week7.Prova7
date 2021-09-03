using AcademyF.Week7.Prova7.Core.Entities;
using AcademyF.Week7.Prova7.Core.Interfaces;
using AcademyF.Week7.Prova7.EF.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week7.Prova7.EF.Repository
{
    public class EFCustomerRepository : EFRepositoryBase<Customer>, ICustomerRepository
    {
        public override DbSet<Customer> GetDbSet()
        {
            return Context.Customers;
        }
    }
}
