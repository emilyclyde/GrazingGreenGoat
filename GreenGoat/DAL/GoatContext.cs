using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenGoat.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GreenGoat.DAL
{
  public class GoatContext : DbContext
  {
    public GoatContext()
      : base("GoatContext")
    {
    }
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