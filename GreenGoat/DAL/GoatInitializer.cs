﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GreenGoat.Models;

namespace GreenGoat.DAL
{
  public class GoatInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GoatContext>
  {
    protected override void Seed(GoatContext context)
    {
      var goats = new List<Goat>
            {
            new Goat{GoatName="Carson",GoatColor="Black", GoatType="Alpine", GoatGender="Buck"},
            new Goat{GoatName="Meredith",GoatColor="White",GoatType="Pygmy", GoatGender="Doe"},
            new Goat{GoatName="Arturo",GoatColor="Red",GoatType="Cross", GoatGender="Doe"},
            new Goat{GoatName="Gytis",GoatColor="Brown",GoatType="Boer", GoatGender="Buck"},
            };

      goats.ForEach(g => context.Goats.Add(g));
      context.SaveChanges();

      var pastures = new List<Pasture>
            {
              new Pasture{GoatID=1, Field="A"},
              new Pasture{GoatID=2, Field="B"},
              new Pasture{GoatID=3, Field="C"},
              new Pasture{GoatID=4, Field="D"},
            };
      pastures.ForEach(p => context.Pastures.Add(p));
      context.SaveChanges();

      var lots = new List<Lot>
            {
            new Lot{LotID= 1, GoatID=1, CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", GoatName="Carson", LotAddress="123 West Ave", LotDescription= "Hill"},
            new Lot{LotID= 2, GoatID=2, CustomerID=2, CustomerFirst="Jerry", CustomerLast="Jones", GoatName="Meredith", LotAddress="456 East Ave", LotDescription= "Trees"},
            new Lot{LotID= 3, GoatID=3, CustomerID=3, CustomerFirst="Timmy", CustomerLast="Wilson",GoatName="Arturo", LotAddress="789 North Ave", LotDescription= "Level"}
            };

      lots.ForEach(l => context.Lots.Add(l));
      context.SaveChanges();

      var customers = new List<Customer>
      {
        new Customer{CustomerID=1, CustomerFirst="Ashley", CustomerLast="Smith", CustomerEmail="ashley@email.com", CustomerAddress="123 West Ave",},
        new Customer{CustomerID=2, CustomerFirst="Jerry",CustomerLast="Jones", CustomerEmail="jerry@email.com", CustomerAddress="456 East Ave"},
        new Customer{CustomerID=3, CustomerFirst="Timmy",CustomerLast="Wilson", CustomerEmail="timmy@email.com", CustomerAddress="789 North Ave"}
      };

      customers.ForEach(c => context.Customers.Add(c));
      context.SaveChanges();
    }
  }
}