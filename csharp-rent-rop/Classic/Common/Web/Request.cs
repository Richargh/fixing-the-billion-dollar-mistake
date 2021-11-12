namespace Richargh.BillionDollar.Classic.Common.Web
{
    public class Request
    {

        public Path Path { get; }
        public string Body { get; }
        
        public Request(Path path, string body)
        {
            Path = path;
            Body = body;
        }
    }
}