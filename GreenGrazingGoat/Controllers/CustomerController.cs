using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GreenGrazingGoat.DAL;
using GreenGrazingGoat.Models;

namespace GreenGrazingGoat.Controllers
{
  public class CustomerController : Controller
  {

    private ICustomerRepository repo;

    //called by the MVC framework thrugh the repository
    public CustomerController()
    {
      this.repo = new CustomerRepository(new GreenContext());
    }

    //called by the unit test this is the fake repository
    public CustomerController(ICustomerRepository fakeRepo)
    {
      this.repo = fakeRepo;
    }

    // GET: Customer
    public ActionResult Index()
    {

      return View(repo.GetCustomers());
    }

    // GET: Customer/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Customer customer = repo.GetCustomerByID((int)id);//use caste to solve the int problem
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // GET: Customer/Create
    public ActionResult Create()
    {

      return View();
    }

    // POST: Customer/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "CustomerID,CustomerFirst,CustomerLast,CustomerAddress,CustomerEmail")] Customer customer)
    {
      if (ModelState.IsValid)
      {
        repo.InsertCustomer(customer);
        repo.Save();
        return RedirectToAction("Index");
      }

      return View(customer);
    }

    // GET: Customer/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Customer customer = repo.GetCustomerByID((int)id);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: Customer/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "CustomerID,CustomerFirst,CustomerLast,CustomerAddress,CustomerEmail")] Customer customer)
    {
      if (ModelState.IsValid)
      {

        repo.Save();
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    // GET: Customer/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Customer customer = repo.GetCustomerByID((int)id);
      if (customer == null)
      {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: Customer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      repo.DeleteCustomer(id);
      repo.Save();
      return RedirectToAction("Index");
    }


    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        repo.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
