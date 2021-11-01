using System;
using System.Linq;
using static Richargh.BillionDollar.Classic.RentResult;

namespace Richargh.BillionDollar.Classic
{
    public class ClassicRentUseCase
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
        
        public RentResult Rent(NotebookType type, EmployeeId eId)
        {
            var employee = _employees.FindById(eId);
            if (employee == null)
            {
                return NotRented;
            }
            if (AlreadyHasANotebook(employee))
            {
                return NotRented;
            }
            var notebook = _inventory
                .FindNotebooksByType(type)
                .FirstOrDefault(IsAvailable);
            if (notebook == null)
            {
                return NotRented;
            }

            var budget = _budget.FindById(eId);
            if (budget is null)
            {
                return NotRented;
            }
            
            if (HasNotEnoughBudget(budget, notebook))
            {
                return NotRented;
            }

            try
            {
                var remainingBudget = RentNotebook(employee, budget, notebook);
                NotifyOfRent(employee, notebook, remainingBudget);
                return Rented;
            }
            catch (MyDbException e)
            {
                Console.WriteLine(e);
                return NotRented;
            }
        }

        private EmployeeBudget RentNotebook(Employee employee, EmployeeBudget budget, Notebook notebook)
        {
            // realistically we'd need some form of transaction/rollback here
            _employees.Put(employee with{NotebookId = notebook.Id});
            _inventory.Put(notebook with{Status = NotebookServiceStatus.Rented});
            var remainingBudget = budget with{Remaining = budget.Remaining - notebook.Cost};
            _budget.Put(remainingBudget);
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