using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.DAL
{
  public class FakeGoatRepository : IGoatRepository
  {
    List<Goat> goats;
    List<Goat> tempGoats = new List<Goat>();

    public FakeGoatRepository(List<Goat> goatList)
    {
      goats = goatList;
      // Make a copy so we can simulate the Save method
      foreach (Goat g in goats)
        tempGoats.Add(g);
    }

    public IEnumerable<Goat> GetGoats()
    {
      return tempGoats;
    }

    public Goat GetGoatByID(int ID)
    {
      return (from g in tempGoats
              where g.ID == ID
              select g).FirstOrDefault();
    }

    public void InsertGoat(Goat goat)
    {
      tempGoats.Add(goat);
    }

    public void DeleteGoat(int ID)
    {
      tempGoats.Remove((from g in tempGoats
                        where g.ID == ID
                        select g).FirstOrDefault());
    }

    public void UpdateGoat(Goat goat)
    {
      // We don't really need this since any changes
      // to tempAuthors will get persisted when
      // the Save method is called anyway.
    }

    public void Save()
    {
      goats.RemoveRange(0, goats.Count());

      foreach (Goat g in tempGoats)
      {
        goats.Add(g);
      }
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}

