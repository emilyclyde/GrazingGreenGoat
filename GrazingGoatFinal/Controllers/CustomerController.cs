using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrazingGoatFinal.DAL;
using GrazingGoatFinal.Models;

namespace GrazingGoatFinal.Controllers
{
  public class CustomerController : Controller
  {
     private UnitOfWork unitOfWork = new UnitOfWork();

    //
    // GET: /Customer/

    public ViewResult Index()
    {
      var customer = unitOfWork.CustomerRepo.Get(includeProperties: "");
      return View(customer.ToList());
    }

    //
    // GET: /Customer/Details/5

    public ViewResult Details(int id)
    {
      Customer customer = unitOfWork.CustomerRepo.GetByID(id);
      return View(customer);
    }

    //
    // GET: /Course/Create

    public ActionResult Create()
    {

      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(
        [Bind(Include = "ID,CustomerFirst,CustomerLast,CustomerAddress,CustomerEmail")]
         Customer customer)
    {
      try
      {
        if (ModelState.IsValid)
        {
          unitOfWork.CustomerRepo.Insert(customer);
          unitOfWork.Save();
          return RedirectToAction("Index");
        }
      }
      catch (DataException /* dex */)
      {
        //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
      }

      return View(customer);
    }

    public ActionResult Edit(int id)
    {
      Customer customer = unitOfWork.CustomerRepo.GetByID(id);
      return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(
         [Bind(Include = "ID,CustomerFirst,CustomerLast,CustomerAddress,CustomerEmail")]
         Customer customer)
    {
      try
      {
        if (ModelState.IsValid)
        {
          unitOfWork.CustomerRepo.Update(customer);
          unitOfWork.Save();
          return RedirectToAction("Index");
        }
      }
      catch (DataException /* dex */)
      {
        //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
      }
      
      return View(customer);
    }

    
    
    // GET: /Customer/Delete/5

    public ActionResult Delete(int id)
    {
      Customer customer = unitOfWork.CustomerRepo.GetByID(id);
      return View(customer);
    }

    //
    // POST: /Customer Delete/5

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Customer customer = unitOfWork.CustomerRepo.GetByID(id);
      unitOfWork.CustomerRepo.Delete(id);
      unitOfWork.Save();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      unitOfWork.Dispose();
      base.Dispose(disposing);
    }
  }
}

 
