using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class DeveloperMistake: Exception
    {
        public DeveloperMistake(string message) 
            : base(message)
        {
        }
        
        public DeveloperMistake(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
        
        protected DeveloperMistake(SerializationInfo info, StreamingContext context)
                : base(info, context)
        {
        }
    }
}