using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class EmailException: Exception
    {
        public EmailException(string message) 
            : base(message)
        {
        }
        
        public EmailException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        
        protected EmailException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}