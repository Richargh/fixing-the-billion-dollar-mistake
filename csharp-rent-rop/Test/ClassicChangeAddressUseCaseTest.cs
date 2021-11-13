using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class ClassicChangeAddressUseCaseTest : ChangeAddressUseCaseContract
    {
        public ClassicChangeAddressUseCaseTest() 
            : base((employees, emailProvider) => new ClassicChangeAddressUseCase(employees, emailProvider))
        {
        }
    }
}