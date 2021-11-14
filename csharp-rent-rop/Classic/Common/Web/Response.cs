namespace Richargh.BillionDollar.Classic.Common.Web
{
    public static class Responses
    {
        public static GoodResponse Good(object data) => Good(data, Status.Ok);
        public static GoodResponse Good(object data, Status status) => new((int)status, data);
        public static BadResponse Bad(Status status, string code, string message) => new((int)status, code, message);
    }
    
    public interface IResponse
    {
        int Status { get; }
    }

    public class GoodResponse : IResponse
    {

        public int Status { get; }
        public object? Body { get; }
        
        
        public GoodResponse(int status)
        {
            Status = status;
            Body = default;
        }
        
        public GoodResponse(int status, object body)
        {
            Status = status;
            Body = body;
        }
    }
    
    public class BadResponse : IResponse
    {
        public object Body { get; }

        public int Status { get; }
        
        public BadResponse(int status, string code, string message)
        {
            Status = status;
            Body = new
            {
                Status = status,
                Code = code,
                Message = message
            };
        }
    }
}