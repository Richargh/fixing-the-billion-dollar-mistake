using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Rop;

namespace Richargh.BillionDollar.Test
{
    public class RopCalculatePriceUseCaseTest : CalculatePriceUseCaseContract
    {
        public RopCalculatePriceUseCaseTest() 
            : base((employeeBenefits, emailProvider) => new RopCalculatePriceUseCase(employeeBenefits, emailProvider))
        {
        }
    }
}