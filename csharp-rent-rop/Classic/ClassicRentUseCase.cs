using System.Linq;
using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Web;
using static Richargh.BillionDollar.Classic.Common.Web.Responses;

namespace Richargh.BillionDollar.Classic
{
    public class ClassicRentUseCase :  IRentUseCase
    {
        private readonly Inventory _inventory;
        private readonly Employees _employees;
        private readonly Budget _budget;
        private readonly IEmailProvider _emailProvider;

        public ClassicRentUseCase(Inventory inventory, Employees employees, Budget budget, IEmailProvider emailProvider)
        {
            _inventory = inventory;
            _employees = employees;
            _budget = budget;
            _emailProvider = emailProvider;
        }
        
        public IResponse Rent(NotebookType type, EmployeeId eId)
        {
            var employee = _employees.FindById(eId);
            if (employee is null)
            {
                return Bad(Status.BadRequest, "", "Employee does not exist");
            }
            if (AlreadyHasANotebook(employee))
            {
                return Bad(Status.BadRequest, "", "Employee already has a notebook");
            }
            var notebook = _inventory
                .FindNotebooksByType(type)
                .FirstOrDefault(IsAvailable);
            if (notebook is null)
            {
                return Bad(Status.BadRequest, "", "No Notebook of desired type is available");
            }

            var budget = _budget.FindById(eId);
            if (budget is null)
            {
                return Bad(Status.BadRequest, "", "Employee has no budget");
            }
            
            if (HasNotEnoughBudget(budget, notebook))
            {
                return Bad(Status.BadRequest, "", "Employee has not enough budget for the notebook");
            }

            var remainingBudget = RentNotebook(employee, budget, notebook);
            try
            {
                NotifyOfRent(employee, notebook, remainingBudget);
                return Good(notebook);
            }
            catch (EmailAddressUnknownException)
            {
                return Bad(Status.Conflict, "", "Could not rent the notebook");
            }
        }

        private EmployeeBudget RentNotebook(Employee employee, EmployeeBudget budget, Notebook notebook)
        {
            // realistically we'd need some form of transaction/rollback here
            _employees.Store(employee with{NotebookId = notebook.Id});
            _inventory.Store(notebook with{Status = NotebookServiceStatus.Rented});
            var remainingBudget = budget with{Remaining = budget.Remaining - notebook.Cost};
            _budget.Store(remainingBudget);
            return remainingBudget;
        }

        private void NotifyOfRent(Employee employee, Notebook notebook, EmployeeBudget remainingBudget)
        {
            var subject = $"Rented '{notebook.Maker} {notebook.Model}' for you";
            var text = $"Your new budget is {remainingBudget.Remaining.Amount}";
            _emailProvider.SendEmail(employee.Id, subject, text);
        }

        private bool HasNotEnoughBudget(EmployeeBudget budget, Notebook notebook) => budget.Remaining < notebook.Cost;

        private bool AlreadyHasANotebook(Employee employee) => employee.NotebookId is not null;

        private bool IsAvailable(Notebook notebook) => notebook.Status == NotebookServiceStatus.Available;
    }
}