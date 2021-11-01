using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public class Employee : IEntity<EmployeeId>
    {
        public EmployeeId Id { get; }
        public string Name { get; }
        
        public Employee(EmployeeId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}