using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class MyDbException: Exception
    {
        public MyDbException(string message) 
            : base(message)
        {
        }
        
        public MyDbException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        
        protected MyDbException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}