using System.Collections.Generic;

namespace Richargh.BillionDollar.Main
{
    public class Addresses
    {
        private readonly Dictionary<PersonId, Address> _addresses = new();
        
        public Address FindAddress(PersonId personId)
        {
            return _addresses[personId];
        }
    }
}