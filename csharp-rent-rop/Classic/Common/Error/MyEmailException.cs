using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class MyEmailException: Exception
    {
        public MyEmailException(string message) 
            : base(message)
        {
        }
        
        public MyEmailException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        
        protected MyEmailException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}