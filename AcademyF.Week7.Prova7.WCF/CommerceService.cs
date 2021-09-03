using AcademyF.Week7.Core;
using AcademyF.Week7.Prova7.Core.BL;
using AcademyF.Week7.Prova7.Core.Entities;
using AcademyF.Week7.Prova7.Core.Interfaces;
using AcademyF.Week7.Prova7.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyF.Week7.Prova7.WCF
{
    
    public class CommerceService : ICommerceService
    {
        public IMainBusinessLayer MainBL { get; set; }
        public CommerceService()
        {
            DependencyContainer.Register<ICustomerRepository, EFCustomerRepository>();
            DependencyContainer.Register<IOrderRepository, EFOrderRepository>();
            DependencyContainer.Register<IMainBusinessLayer, MainBusinessLayer>();

            MainBL = DependencyContainer.Resolve<IMainBusinessLayer>();
        }
        public bool CreateCustomer(Customer customer)
        {
            if (customer == null)
                return false;
            return MainBL.CreateCustomer(customer);
        }

        public bool DeleteCustomerById(int id)
        {
            if (id <= 0)
                return false;
            return MainBL.DeleteCustomerById(id);
        }

        public List<Customer> FetchAllCustomers()
        {
            return MainBL.FetchAllCustomers();
        }

        public Customer GetCustomerById(int idCustomer)
        {
            if (idCustomer <= 0)
                return null;
            return MainBL.GetCustomerById(idCustomer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
                return false;

            return MainBL.UpdateCustomer(customer);
        }
    }
}
