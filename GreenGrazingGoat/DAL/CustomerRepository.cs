using GreenGrazingGoat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GreenGrazingGoat.DAL
{

  public class CustomerRepository : ICustomerRepository, IDisposable
  {
    private GreenContext context;

    public CustomerRepository(GreenContext context)
    {
      this.context = context;
    }

    public IEnumerable<Customer> GetCustomers()
    {
      return context.Customers.ToList();
    }

    public Customer GetCustomerByID(int id)
    {
      return context.Customers.Find(id);
    }

    public void InsertCustomer(Customer customer)
    {
      context.Customers.Add(customer);
    }

    public void DeleteCustomer(int customerID)
    {
      Customer customer = context.Customers.Find(customerID);
      context.Customers.Remove(customer);
    }

    public void UpdateCustomer(Customer customer)
    {
      context.Entry(customer).State = EntityState.Modified;
    }

    public void Save()
    {
      context.SaveChanges();
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}

