using System;

namespace QBank.Infrastructure.Web.WCF
{
    public interface IFakeService
    {
        Int32 DoSomething(string parameters);
    }
}