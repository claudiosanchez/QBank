// Type: EntityFramework.Patterns.Repository`1
// Assembly: EntityFramework.Patterns, Version=0.7.0.32308, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Claudio\SkyDrive\Source Code\QBank\packages\EntityFramework.Patterns.0.7\lib\net40\EntityFramework.Patterns.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFramework.Patterns
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly IObjectSet<T> _objectSet;
    private readonly IObjectSetFactory _objectSetFactory;

    public Repository(IObjectSetFactory objectSetFactory)
    {
      this._objectSet = objectSetFactory.CreateObjectSet<T>();
      this._objectSetFactory = objectSetFactory;
    }

    public IQueryable<T> AsQueryable()
    {
      return (IQueryable<T>) this._objectSet;
    }

    public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = this.AsQueryable();
      return (IEnumerable<T>) Repository<T>.PerformInclusions((IEnumerable<Expression<Func<T, object>>>) includeProperties, query);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = this.AsQueryable();
      return (IEnumerable<T>) Queryable.Where<T>(Repository<T>.PerformInclusions((IEnumerable<Expression<Func<T, object>>>) includeProperties, query), where);
    }

    public T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = this.AsQueryable();
      return Queryable.Single<T>(Repository<T>.PerformInclusions((IEnumerable<Expression<Func<T, object>>>) includeProperties, query), where);
    }

    public T First(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = this.AsQueryable();
      return Queryable.First<T>(Repository<T>.PerformInclusions((IEnumerable<Expression<Func<T, object>>>) includeProperties, query), where);
    }

    public void Delete(T entity)
    {
      this._objectSet.DeleteObject(entity);
    }

    public void Insert(T entity)
    {
      this._objectSet.AddObject(entity);
    }

    public void Update(T entity)
    {
      this._objectSet.Attach(entity);
      this._objectSetFactory.ChangeObjectState((object) entity, EntityState.Modified);
    }

    private static IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties, IQueryable<T> query)
    {
      return Enumerable.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(includeProperties, query, (Func<IQueryable<T>, Expression<Func<T, object>>, IQueryable<T>>) ((current, includeProperty) => DbExtensions.Include<T, object>(current, includeProperty)));
    }
  }
}
