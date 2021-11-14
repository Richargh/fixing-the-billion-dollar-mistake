using Richargh.BillionDollar.Rop;

namespace Richargh.BillionDollar.Test
{
    public class RopChangeAddressUseCaseTest : ChangeAddressUseCaseContract
    {
        public RopChangeAddressUseCaseTest() 
            : base((employees, emailProvider) => new RopChangeAddressUseCase(employees, emailProvider))
        {
        }
    }
}