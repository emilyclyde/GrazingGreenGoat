using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.Models
{
  public class Pasture
  {
    public int ID { get; set; }
    public int GoatID { get; set; }
    public string Field { get; set; }
    public virtual Goat Goat { get; set; }
  }
}