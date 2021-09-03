using AcademyF.Week7.Core;
using AcademyF.Week7.Prova7.Core.Entities;
using AcademyF.Week7.Prova7.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyF.Week7.Prova7.Core.BL
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        public ICustomerRepository CustomerRepo { get; set; }
        public IOrderRepository OrderRepo { get; set; }
        public MainBusinessLayer()
        {
            CustomerRepo = DependencyContainer.Resolve<ICustomerRepository>();
            OrderRepo = DependencyContainer.Resolve<IOrderRepository>();
        }

        public MainBusinessLayer(ICustomerRepository customerRepo, IOrderRepository orderRepo)
        {
            CustomerRepo = customerRepo;
            OrderRepo = orderRepo;
        }

        public bool CreateCustomer(Customer customer)
        {
            if (customer == null)
                return false;

            return CustomerRepo.Create(customer);
        }

        public bool CreateOrder(Order order)
        {
            if (order == null)
                return false;
            return OrderRepo.Create(order);
        }

        public bool DeleteCustomerById(int id)
        {
            if (id <= 0)
                return false;
            return CustomerRepo.Delete(id);
        }

        public bool DeleteOrderById(int id)
        {
            if (id <= 0)
                return false;
            return OrderRepo.Delete(id);
        }

        public List<Customer> FetchAllCustomers(Func<Customer, bool> filter = null)
        {
            return CustomerRepo.Fetch(filter);
        }

        public List<Order> FetchAllOrders(Func<Order, bool> filter = null)
        {
            return OrderRepo.Fetch(filter);
        }

        public Customer GetCustomerById(int id)
        {
            if (id <= 0)
                return null;
            return CustomerRepo.Get(id);
        }

        public Order GetOrderById(int id)
        {
            if (id <= 0)
                return null;
            return OrderRepo.Get(id);
        }

        public List<Order> GetOrdersByCustomerId(int customerId)
        {
            return OrderRepo.Fetch().Where(o=>o.CustomerId==customerId).ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            if (customer == null)
                return false;
            return CustomerRepo.Update(customer);
        }

        public bool UpdateOrder(Order order)
        {
            if (order == null)
                return false;
            return OrderRepo.Update(order);
        }
    }
}
