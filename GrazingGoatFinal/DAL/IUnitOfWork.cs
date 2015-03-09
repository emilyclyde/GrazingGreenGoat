using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrazingGoatFinal.DAL
{
  interface IUnitofWork : IDisposable
  {
    IFinalRepo<Customer> CustomerRepo { get; }
    IFinalRepo<Goat> GoatRepo { get; }
    IFinalRepo<Lot> LotRepo { get; }
    void Save();
  }
}
