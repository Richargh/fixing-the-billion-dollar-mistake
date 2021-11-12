using System;
using System.Runtime.Serialization;

namespace Richargh.BillionDollar.Classic.Common.Error
{
    [Serializable]
    public class SwitchNotExhaustiveException: DeveloperMistake
    {
        public SwitchNotExhaustiveException(object theCase)
            : base($"Did not handle case [{theCase}] of Type [{theCase.GetType().Name}].")
        {
        }
        
        protected SwitchNotExhaustiveException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}