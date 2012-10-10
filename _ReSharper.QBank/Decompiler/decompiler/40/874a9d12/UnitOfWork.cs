// Type: EntityFramework.Patterns.UnitOfWork
// Assembly: EntityFramework.Patterns, Version=0.7.0.32308, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\Users\Claudio\SkyDrive\Source Code\QBank\packages\EntityFramework.Patterns.0.7\lib\net40\EntityFramework.Patterns.dll

using System;

namespace EntityFramework.Patterns
{
  public class UnitOfWork : IUnitOfWork, IDisposable
  {
    private readonly IObjectContext _objectContext;

    public UnitOfWork(IObjectContext objectContext)
    {
      this._objectContext = objectContext;
    }

    public void Dispose()
    {
      if (this._objectContext != null)
        this._objectContext.Dispose();
      GC.SuppressFinalize((object) this);
    }

    public void Commit()
    {
      this._objectContext.SaveChanges();
    }
  }
}
