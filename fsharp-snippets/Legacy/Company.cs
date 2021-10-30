using System.Collections.Generic;
using System.Linq;

namespace Richargh.BillionDollar.Legacy
{
    public class Company
    {
        private readonly Dictionary<EmployeeId, Employee> _allEmployees;
        
        public Company(IEnumerable<Employee> employees)
        {
            _allEmployees = employees.ToDictionary(it => it.Id);
        }
        public Company(params Employee[] employees) : this(employees.ToList()) { }
        
        public Employee? FindById(EmployeeId id)
        {
            return _allEmployees.GetValueOrDefault(id);
        }
        
        public void Put(Employee employee)
        {
            _allEmployees[employee.Id] = employee;
        }
    }
}
