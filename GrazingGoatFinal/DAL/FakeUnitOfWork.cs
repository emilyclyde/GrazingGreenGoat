using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.DAL
{
  public class FakeUnitofWork : IUnitofWork
  {

    private IFinalRepo<Customer> customerRepo;
    private IFinalRepo<Goat> goatRepo;
    private IFinalRepo<Lot> lotRepo;

    private List<Customer> customers;
    private List<Goat> goats;
    private List<Lot> lots;

    public FakeUnitofWork(List<Customer> c = null, List<Goat> g = null, List<Lot> l = null)
    {
      if (c == null)
        customers = new List<Customer>();
      else
        customers = c;

      if (g == null)
        goats = new List<Goat>();
      else
        goats = g;
      if (l == null)
        lots = new List<Lot>();
      else
        lots = l;
    }

    public IFinalRepo<Models.Customer> CustomerRepo
    {
      get
      {
        if (this.customerRepo == null)
        {
          this.customerRepo = new FakeFinalRepo<Customer>(customers);
        }
        return customerRepo;
      }
    }

    public IFinalRepo<Models.Goat> GoatRepo
    {
      get
      {
        if (this.goatRepo == null)
        {
          this.goatRepo = new FakeFinalRepo<Goat>(goats);
        }
        return goatRepo;
      }
    }

    public IFinalRepo<Models.Lot> LotRepo
    {
      get
      {
        if (this.LotRepo == null)
        {
          this.lotRepo = new FakeFinalRepo<Lot>(lots);
        }
        return lotRepo;
      }
    }

    public void Save()
    {
      // Nothing to do here
    }

    public void Dispose()
    {
      // Nothing to do here
    }
  }
}