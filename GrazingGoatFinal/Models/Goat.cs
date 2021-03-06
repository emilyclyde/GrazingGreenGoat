﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.Models
{
  public class Goat : IEntityModel
  {
    [Column("GoatID")]
    [Display(Name = "Goat ID")]
    public int ID { get; set; }

    [Column("GoatName")]
    [Display(Name = "Goat Name")]
    public string GoatName { get; set; }

    [Column("GoatColor")]
    [Display(Name = "Goat Color")]
    public string GoatColor { get; set; }

    [Column("GoatType")]
    [Display(Name = "Goat Type")]
    public string GoatType { get; set; }

    [Column("GoatGender")]
    [Display(Name = "Goat Gender")]
    public string GoatGender { get; set; }

    public virtual ICollection<Pasture> Pastures { get; set; }

    public virtual Lot Lot { get; set; }
  }
}