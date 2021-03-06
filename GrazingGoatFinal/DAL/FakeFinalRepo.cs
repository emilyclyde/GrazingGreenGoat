﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrazingGoatFinal.Models;
using System.Data.Entity;


namespace GrazingGoatFinal.DAL
{
  public class FakeFinalRepo<TEntity> : IFinalRepo<TEntity> where TEntity : IEntityModel
  {
    List<TEntity> entities;

    public FakeFinalRepo(List<TEntity> entitiesList)
    {
      entities = entitiesList;
    }

    public IEnumerable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
    {
      var query = entities.AsQueryable<TEntity>();

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split
          (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (orderBy != null)
      {
        return orderBy(query).ToList();
      }
      else
      {
        return query.ToList();
      }
    }

    public virtual TEntity GetByID(object id)
    {
      return (from e in entities
              where e.ID == (int)id
              select e).FirstOrDefault();
    }

    public virtual void Insert(TEntity entity)
    {
      entities.Add(entity);
    }

    public virtual void Delete(object id)
    {

      TEntity entityToDelete = GetByID(id);
      Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
      // TODO: How do I simulate state?
      /*
      if (context.Entry(entityToDelete).State == EntityState.Detached)
      {
          dbSet.Attach(entityToDelete);
      }
      */
      entities.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
      // TODO: simulate Attach and state
      /* dbSet.Attach(entityToUpdate);
      context.Entry(entityToUpdate).State = EntityState.Modified;
      */
    }
  }
}
  
  
