namespace Richargh.BillionDollar.Classic.Common.Web
{
    public static class Responses
    {
        public static OkResponse Ok(object data) => Ok(200, data);
        public static OkResponse Ok(int status, object data) => new(data, status);
        public static BadResponse Bad(string message, int status) => new(status, message);
    }
    
    public interface IResponse
    {
        int Status { get; }
    }

    public class OkResponse : IResponse
    {
        public object? Data { get; }

        public int Status { get; }
        
        public OkResponse(object data, int status)
        {
            Data = data;
            Status = status;
        }
        
        public OkResponse(int status)
        {
            Data = default;
            Status = status;
        }
    }
    
    public class BadResponse : IResponse
    {
        public string Message { get; }

        public int Status { get; }
        
        public BadResponse(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}