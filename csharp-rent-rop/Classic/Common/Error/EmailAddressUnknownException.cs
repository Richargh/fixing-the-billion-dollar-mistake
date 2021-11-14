using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class EmailAddressUnknownException: EmailException
    {
        public EmailAddressUnknownException(string message) 
            : base(message)
        {
        }
        
        public EmailAddressUnknownException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        
        protected EmailAddressUnknownException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}