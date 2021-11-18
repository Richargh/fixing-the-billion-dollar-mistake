using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public class Employees
    {
        private SimpleRepository<EmployeeId, Employee> _employees;
        
        public Employees(params Employee[] employees)
        {
            _employees = new SimpleRepository<EmployeeId, Employee>(employees);
        }
        
        public Employee? FindById(EmployeeId id) 
            => _employees.FindById(id);

        public Employee? FindByEmail(EmailAddress address) 
            => _employees.Find(pair => address.Equals(pair.Value.EmailAddress));

        public void Store(Employee employee)
        {
            _employees.Put(employee);
        }
    }
}