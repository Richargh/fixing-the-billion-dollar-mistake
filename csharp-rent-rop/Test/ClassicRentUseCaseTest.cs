using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class ClassicRentUseCaseTest : RentUseCaseContract
    {
        public ClassicRentUseCaseTest() 
            : base((inventory, employees, budget, emailProvider) => new ClassicRentUseCase(inventory, employees, budget, emailProvider))
        {
        }
    }
}