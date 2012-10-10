namespace QBank.Infrastructure.Web.WCF
{
    public class OperationResults<TResult> : OperationResults
    {
        public OperationResults(TResult result, bool success, string message = "") : base(success, message)
        {
            Result = result;
        }

        public TResult Result { get; private set; }
    }

    public class OperationResults
    {
        public OperationResults(bool success, string message = "")
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; private set; }
    }
}