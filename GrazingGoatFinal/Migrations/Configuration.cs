namespace GrazingGoatFinal.Migrations
{
    using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GrazingGoatFinal.DAL.FinalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GrazingGoatFinal.DAL.FinalContext context)
        {
            var goats = new List<Goat>
            {
            new Goat{ID=1, GoatName="Carson",GoatColor="Black", GoatType="Alpine", GoatGender="Buck"},
            new Goat{ID=2, GoatName="Meredith",GoatColor="White",GoatType="Pygmy", GoatGender="Doe"},
            new Goat{ID=3, GoatName="Arturo",GoatColor="Red",GoatType="Cross", GoatGender="Doe"},
            new Goat{ID=4, GoatName="Gytis",GoatColor="Brown",GoatType="Boer", GoatGender="Buck"},
            };

      
      goats.ForEach(g => context.Goats.AddOrUpdate(g));
      context.SaveChanges();

      var pastures = new List<Pasture>
            {
              new Pasture{ID= 1, GoatID=1, Field="A"},
              new Pasture{ID= 2, GoatID=2, Field="B"},
              new Pasture{ID= 3, GoatID=3, Field="C"},
              new Pasture{ID= 4, GoatID=4, Field="D"},
              
            };
      
      pastures.ForEach(p => context.Pastures.AddOrUpdate(p));
      context.SaveChanges();

      var lots = new List<Lot>
            {
            new Lot{ID=1, GoatID=1, CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", GoatName="Carson", LotAddress="123 West Ave", LotDescription= "Hill"},
            new Lot{ID=2, GoatID=2, CustomerID=2, CustomerFirst="Jerry", CustomerLast="Jones", GoatName="Meredith", LotAddress="456 East Ave", LotDescription= "Trees"},
            new Lot{ID=3, GoatID=3, CustomerID=3, CustomerFirst="Timmy", CustomerLast="Wilson",GoatName="Arturo", LotAddress="789 North Ave", LotDescription= "Level"},
            new Lot{ID=4, GoatID=4, CustomerID=4, CustomerFirst="Leo", CustomerLast="Lion",GoatName="Gytis", LotAddress="100 South Ave", LotDescription= "Level"}
            };

      lots.ForEach(l => context.Lots.AddOrUpdate(l));
      context.SaveChanges();

      var customers = new List<Customer>
      {
        new Customer{ID=1, CustomerFirst="Ashley", CustomerLast="Smith", CustomerEmail="ashley@email.com", CustomerAddress="123 West Ave",},
        new Customer{ID=2, CustomerFirst="Jerry",CustomerLast="Jones", CustomerEmail="jerry@email.com", CustomerAddress="456 East Ave"},
        new Customer{ID=3, CustomerFirst="Timmy",CustomerLast="Wilson", CustomerEmail="timmy@email.com", CustomerAddress="789 North Ave"},
        new Customer{ID=4, CustomerFirst="Leo",CustomerLast="Lion", CustomerEmail="leo@email.com", CustomerAddress="100 South Ave"}
      };

      customers.ForEach(c => context.Customers.AddOrUpdate(c));
      context.SaveChanges();
    }
  }
}
        

