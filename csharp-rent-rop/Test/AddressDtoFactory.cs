using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class AddressDtoFactory
    {
        public static AddressDto AnAddress() => new(
            "Vilnius", 
            "Konstitucijos Av. 20"); 
    }
}