using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public class EmployeeBenefits
    {
        private readonly SimpleRepository<EmployeeId, EmployeeBenefit> _allBenefits;
        
        public EmployeeBenefits(params EmployeeBenefit[] employeeBenefits)
        {
            _allBenefits = new SimpleRepository<EmployeeId, EmployeeBenefit>(employeeBenefits);
        }
        
        public EmployeeBenefit? FindById(EmployeeId id)
        {
            return _allBenefits.FindById(id);
        }

        public void Store(EmployeeBenefit budget)
        {
            _allBenefits.Put(budget);
        }
    }
}