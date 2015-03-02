using GreenGrazingGoat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenGrazingGoat.DAL
{
  public interface ICustomerRepository : IDisposable 
  {
    IEnumerable<Customer> GetCustomers();
    Customer GetCustomerByID(int customerId);
    void InsertCustomer(Customer customer);
    void DeleteCustomer(int customerID);
    void UpdateCustomer(Customer customer);
    void Save();
  }
}