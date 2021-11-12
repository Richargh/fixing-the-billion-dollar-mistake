using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Rop.Common.Rop;

namespace Richargh.BillionDollar.Rop
{
    public record RopUseCaseScope(Employee? Employee, Notebook? Notebook, EmployeeBudget? EmployeeBudget)
    : IScope
    {
        public static RopUseCaseScope Empty() => new(null, null, null);
    }
}