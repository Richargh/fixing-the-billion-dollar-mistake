namespace Richargh.BillionDollar.Classic.Common.Error
{
    public class Failure
    {

        public Status Status { get; }
        public string Code { get; }
        public string Message { get; }
        
        public Failure(Status status, string code, string message)
        {
            Status = status;
            Code = code;
            Message = message;
        }
    }

}