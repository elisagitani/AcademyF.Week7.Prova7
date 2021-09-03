using AcademyF.Week7.Prova7.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AcademyF.Week7.Prova7.WCF
{
    
    [ServiceContract]
    public interface ICommerceService
    {
        [OperationContract]
        List<Customer> FetchAllCustomers();

        [OperationContract]
        Customer GetCustomerById(int idCustomer);

        [OperationContract]
        bool CreateCustomer(Customer customer);

        [OperationContract]
        bool UpdateCustomer(Customer customer);

        [OperationContract]
        bool DeleteCustomerById(int id);

    }

    
}
