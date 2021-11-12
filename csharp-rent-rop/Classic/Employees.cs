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
        {
            return _employees.FindById(id);
        }

        public void Store(Employee employee)
        {
            _employees.Put(employee);
        }
    }
}