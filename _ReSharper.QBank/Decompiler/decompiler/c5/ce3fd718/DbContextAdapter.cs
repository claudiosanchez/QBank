// Type: EntityFramework.Patterns.DbContextAdapter
// Assembly: EntityFramework.Patterns, Version=0.7.0.32308, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Claudio\SkyDrive\Source Code\QBank\packages\EntityFramework.Patterns.0.7\lib\net40\EntityFramework.Patterns.dll

using System;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;

namespace EntityFramework.Patterns
{
  public class DbContextAdapter : IObjectSetFactory, IObjectContext, IDisposable
  {
    private readonly ObjectContext _context;

    public DbContextAdapter(DbContext context)
    {
      this._context = DbContextExtensions.GetObjectContext(context);
    }

    public void SaveChanges()
    {
      this._context.SaveChanges();
    }

    public void Dispose()
    {
      this._context.Dispose();
    }

    public IObjectSet<T> CreateObjectSet<T>() where T : class
    {
      return (IObjectSet<T>) this._context.CreateObjectSet<T>();
    }

    public void ChangeObjectState(object entity, EntityState state)
    {
      this._context.ObjectStateManager.ChangeObjectState(entity, state);
    }
  }
}
