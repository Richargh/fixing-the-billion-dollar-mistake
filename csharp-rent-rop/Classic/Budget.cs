using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public class Budget
    {
        private readonly SimpleRepository<EmployeeId, EmployeeBudget> _budget;
        
        public Budget(params EmployeeBudget[] employeeBudgets)
        {
            _budget = new SimpleRepository<EmployeeId, EmployeeBudget>(employeeBudgets);
        }
        
        public EmployeeBudget? FindById(EmployeeId id)
        {
            return _budget.FindById(id);
        }

        public void Store(EmployeeBudget budget)
        {
            _budget.Put(budget);
        }
    }
}