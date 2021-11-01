namespace Richargh.BillionDollar.Classic.Common.Web
{
    public static class Responses
    {
        public static OkResponse<T> Ok<T>(T data, int status = 200) => new OkResponse<T>(data, status);
        public static BadResponse Bad(string message, int status) => new BadResponse(message, status);
    }
    
    public interface IResponse
    {
        int Status { get; }
    }

    public class OkResponse<T> : IResponse
    {
        public T Data { get; }

        public int Status { get; }
        
        public OkResponse(T data, int status)
        {
            Data = data;
            Status = status;
        }
    }
    
    public class BadResponse : IResponse
    {
        public string Message { get; }

        public int Status { get; }
        
        public BadResponse(string message, int status)
        {
            Message = message;
            Status = status;
        }
    }
}