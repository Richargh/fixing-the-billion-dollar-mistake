using System;
using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public record EmployeeBudget(EmployeeId Id, Money Remaining) : IEntity<EmployeeId>;
}