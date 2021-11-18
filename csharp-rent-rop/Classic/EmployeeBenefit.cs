using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public record EmployeeBenefit(EmployeeId Id, Months WithCompanyFor) : IEntity<EmployeeId>;
}