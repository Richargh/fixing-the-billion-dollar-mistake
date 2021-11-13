using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public record Employee(EmployeeId Id, Name Name, EmailAddress EmailAddress, Address Address, NotebookId? NotebookId) : IEntity<EmployeeId>
    {
        public Employee ChangeAddress(Address address)
        {
            return this with {Address = address};
        }
    }
}