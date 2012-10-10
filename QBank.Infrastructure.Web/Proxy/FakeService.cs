using System;

namespace QBank.Infrastructure.Web.WCF
{
    public class FakeService: IFakeService
    {
        #region Implementation of IFakeService

        public int DoSomething(string parameters)
        {
            int v;
            Int32.TryParse(parameters, out v);
            return v;
        }

        #endregion
    }
}