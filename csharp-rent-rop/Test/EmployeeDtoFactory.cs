using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class EmployeeDtoFactory
    {
        public static EmployeeDto AnEmployee(string id = "1", string email = "foo@bar.de") => new(
            id, 
            "Alex",
            email,
            AddressDtoFactory.AnAddress()); 
    }
}