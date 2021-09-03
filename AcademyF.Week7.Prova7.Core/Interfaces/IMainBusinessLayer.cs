using AcademyF.Week7.Prova7.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyF.Week7.Prova7.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region CUSTOMER
        List<Customer> FetchAllCustomers(Func<Customer, bool> filter = null);
        Customer GetCustomerById(int id);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomerById(int id);
        #endregion

        #region ORDER
        List<Order> FetchAllOrders(Func<Order, bool> filter = null);
        Order GetOrderById(int id);
        bool CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrderById(int id);

        #endregion

        #region OTHER OPERATIONS

        List<Order> GetOrdersByCustomerId(int customerId);

        #endregion
    }
}
