using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.DAL
{

  public class UnitOfWork : IUnitofWork
  {
    private FinalContext context = new FinalContext();
    private IFinalRepo<Customer> customerRepo;
    private IFinalRepo<Goat> goatRepo;
    private IFinalRepo<Lot> lotRepo;


    public IFinalRepo<Models.Customer> CustomerRepo
    {
      get
      {
        if (this.customerRepo == null)
        {
          this.customerRepo = new FinalContextRepo<Customer>(context);
        }
        return customerRepo;
      }
    }

    public IFinalRepo<Goat> GoatRepo
    {
      get
      {
        if (this.goatRepo == null)
        {
          this.goatRepo = new FinalContextRepo<Goat>(context);
        }
        return goatRepo;
      }
    }

    public IFinalRepo<Lot> LotRepo
    {
      get
      {
        if (this.lotRepo == null)
        {
          this.lotRepo = new FinalContextRepo<Lot>(context);
        }
        return lotRepo;
      }

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




