using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.Models
{
  public class Customer : IEntityModel
  {

    public int ID { get; set; }
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Column("CustomerFirst")]
    [Display(Name = "First Name")]
    public string CustomerFirst { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
    [Column("CustomerLast")]
    [Display(Name = "Last Name")]
    public string CustomerLast { get; set; }

    [Column("CustomerAddress")]
    [Display(Name = "Address")]
    public string CustomerAddress { get; set; }

    [Column("CustomerEmail")]
    [Display(Name = "Email")]
    public string CustomerEmail { get; set; }

    public virtual Goat Goat { get; set; }
    public virtual Lot Lot { get; set; }
  }
}
  