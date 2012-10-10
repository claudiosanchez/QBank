using System;
using QBank.Infrastructure.Web.Proxy;

namespace QBank.Infrastructure.Web.WCF
{
    public class FakeServiceProxy : DynamicWebServiceProxy<IFakeService>
    {
        public Int32 DoSomething(string parameters)
        {
            var result =  CallOperationOnClient(() => Client.DoSomething(parameters));

            return result.Success ? result.Result : 0;
        }
    }
}