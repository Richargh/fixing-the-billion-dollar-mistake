using Richargh.BillionDollar.Rop;

namespace Richargh.BillionDollar.Test
{
    public class RopRentUseCaseTest : RentUseCaseContract
    {
        public RopRentUseCaseTest() 
            : base((inventory, employees, budget, emailProvider) => new RopRentUseCase(inventory, employees, budget, emailProvider))
        {
        }
    }
}