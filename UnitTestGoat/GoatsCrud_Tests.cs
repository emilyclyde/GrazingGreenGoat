using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GrazingGoatFinal.Models;
using GrazingGoatFinal.Controllers;
using GrazingGoatFinal.DAL;

namespace UnitTestGoat
{
  [TestClass]
  public class GoatsCrud_Tests
  {
    [TestMethod]
    public void Create_Goat_Test()
    {
      // arrange
      List<Goat> goats = new List<Goat>();
      var target = new GoatController(new FakeGoatRepository(goats));

      // act
      const string NAME = "Molly Mea";
      var goat = new Goat() { GoatName = NAME };
      target.Create(goat);

      // assert
      Assert.AreEqual(NAME, goats[0].GoatName);
    }

    [TestMethod]
        public void Delete_Goat_Test()
        {
            // arrange
            List<Goat> goats = new List<Goat>();
            var goat = new Goat() { GoatName = "Molly Mea", ID=1 };
            goats.Add(goat);
            const string NAME = "Maggie Sue";
            goat = new Goat() { GoatName = NAME, ID=2 };
            goats.Add(goat);

            var target = new GoatController(new FakeGoatRepository(goats));

            // act
            target.DeleteConfirmed(2);

            // assert
            Assert.AreEqual(1,goats.Count);
            Assert.AreNotEqual(NAME, goats[0].GoatName);

        }
    }
}
  
