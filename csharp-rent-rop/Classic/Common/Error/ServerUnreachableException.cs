using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class ServerUnreachableException: EmailException
    {
        public ServerUnreachableException(string message) 
            : base(message)
        {
        }
        
        public ServerUnreachableException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        
        protected ServerUnreachableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}