using Richargh.BillionDollar.Rop;

namespace Richargh.BillionDollar.Test
{
    public class RopRegisterEmployeeUseCaseTest : RegisterEmployeeUseCaseContract
    {
        public RopRegisterEmployeeUseCaseTest() 
            : base((employees, emailProvider) => new RopRegisterEmployeeUseCase(employees, emailProvider))
        {
        }
    }
}