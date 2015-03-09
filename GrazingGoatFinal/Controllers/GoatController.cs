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
    public class GoatController : Controller
    {
        //private FinalContext db = new FinalContext();

        private IGoatRepository repo;

      public GoatController()
        {
            repo = new GoatRepository(new FinalContext());
        }
      public GoatController(IGoatRepository fakeRepo)
        {
            repo = fakeRepo;
        }
        // GET: Goat
        public ActionResult Index()
        {
            //return View(db.Goats.ToList());
          return View(repo.GetGoats());
        }

        // GET: Goat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goat goat = repo.GetGoatByID((int)id);  
          //Goat goat = db.Goats.Find(id);
            if (goat == null)
            {
                return HttpNotFound();
            }
            return View(goat);
        }

        // GET: Goat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GoatName,GoatColor,GoatType,GoatGender")] Goat goat)
        {
            if (ModelState.IsValid)
            {
              repo.InsertGoat(goat);
              repo.Save();
                //db.Goats.Add(goat);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goat);
        }

        // GET: Goat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goat goat = repo.GetGoatByID((int)id);
          //Goat goat = db.Goats.Find(id);
            if (goat == null)
            {
                return HttpNotFound();
            }
            return View(goat);
        }

        // POST: Goat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GoatName,GoatColor,GoatType,GoatGender")] Goat goat)
        {
            if (ModelState.IsValid)
            {
              repo.UpdateGoat(goat);
              repo.Save();  
              //db.Entry(goat).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goat);
        }

        // GET: Goat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Goat goat = repo.GetGoatByID((int)id);
          //Goat goat = db.Goats.Find(id);
            if (goat == null)
            {
                return HttpNotFound();
            }
            return View(goat);
        }

        // POST: Goat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          repo.DeleteGoat(id);
          repo.Save();  
          //Goat goat = db.Goats.Find(id);
            //db.Goats.Remove(goat);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              repo.Dispose();  
              //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
