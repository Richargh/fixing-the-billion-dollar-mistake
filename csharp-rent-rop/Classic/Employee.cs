using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public record Employee(EmployeeId Id, string Name, NotebookId? NotebookId) : IEntity<EmployeeId>;
}