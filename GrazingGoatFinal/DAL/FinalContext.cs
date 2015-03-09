using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.DAL
{
  public class FinalContext : DbContext
  {
    public FinalContext()
      : base("FinalContext")
    { }

    public DbSet<Goat> Goats { get; set; }
    public DbSet<Lot> Lots { get; set; }
    public DbSet<Pasture> Pastures { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}
