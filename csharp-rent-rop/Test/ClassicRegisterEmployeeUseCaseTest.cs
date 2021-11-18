using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class ClassicRegisterEmployeeUseCaseTest : RegisterEmployeeUseCaseContract
    {
        public ClassicRegisterEmployeeUseCaseTest() 
            : base((employees, emailProvider) => new ClassicRegisterEmployeeUseCase(employees, emailProvider))
        {
        }
    }
}