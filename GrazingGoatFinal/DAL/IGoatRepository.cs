using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrazingGoatFinal.DAL
{
  public interface IGoatRepository : IDisposable
    {
        IEnumerable<Goat> GetGoats();
        Goat GetGoatByID(int ID);
        void InsertGoat(Goat goat);
        void DeleteGoat(int ID);
        void UpdateGoat(Goat goat);
        void Save();
  }
}
