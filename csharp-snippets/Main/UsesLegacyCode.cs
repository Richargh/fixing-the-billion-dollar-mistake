using Legacy;

namespace Richargh.BillionDollar
{
    public class UsesLegacyCode
    {
        private readonly Company _company;

        public UsesLegacyCode(Company company)
        {
            _company = company;
        }
        
        public string? FindNotebookMaker(EmployeeId id)
        {
            var employee = _company.FindById(id);
            // we guard against person being null but forget about the object properties
            if (employee is null)
                return null;
            /* ... */
            // compiles just fine even though Notebook is not necessarily set 
            return employee.Notebook.Maker;
        }
    }
}