using GrazingGoatFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GrazingGoatFinal.DAL
{
 public class GoatRepository : IGoatRepository, IDisposable
    {
        private FinalContext context;

        public GoatRepository(FinalContext c)
        {
            context = c;
        }

        public IEnumerable<Models.Goat> GetGoats()
        {
            return context.Goats.ToList();
        }

        public Models.Goat GetGoatByID(int ID)
        {
          return context.Goats.Find(ID);
        }

        public void InsertGoat(Goat goat)
        {
          context.Goats.Add(goat);
        }

        public void DeleteGoat(int ID)
        {
          Goat goat = context.Goats.Find(ID);
          context.Goats.Remove(goat);
        }

        public void UpdateGoat(Models.Goat goat)
        {
            context.Entry(goat).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
