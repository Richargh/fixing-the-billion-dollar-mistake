using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class ClassicCalculatePriceUseCaseTest : CalculatePriceUseCaseContract
    {
        public ClassicCalculatePriceUseCaseTest() 
            : base((employeeBenefits, emailProvider) => new ClassicCalculatePriceUseCase(employeeBenefits, emailProvider))
        {
        }
    }
}