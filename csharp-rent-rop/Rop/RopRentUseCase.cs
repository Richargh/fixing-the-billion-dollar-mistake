using System.Linq;
using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common.Web;
using Richargh.BillionDollar.Rop.Common.Rop;

namespace Richargh.BillionDollar.Rop
{
    public class RopRentUseCase : IRentUseCase
    {
        private readonly Inventory _inventory;
        private readonly Employees _employees;
        private readonly Budget _budget;
        private readonly IEmailProvider _emailProvider;

        public RopRentUseCase(Inventory inventory, Employees employees, Budget budget, IEmailProvider emailProvider)
        {
            _inventory = inventory;
            _employees = employees;
            _budget = budget;
            _emailProvider = emailProvider;
        }
        
        public IResponse Rent(NotebookType type, EmployeeId eId)
        {
            var employeeR = FindEmployee(eId)
                .Map(HasNoExistingNotebook);
            var notebookR = FirstNotebookOfType(type);
            return new BadResponse(500, "todo");
            // BudgetForEmployee(eId)
            //     .Map2(notebookR, HasEnoughBudget);
            //     .Map3(RentNotebook)
            //
            // try
            // {
            //     var remainingBudget = RentNotebook(employeeR, budget, notebookR);
            //     NotifyOfRent(employeeR, notebookR, remainingBudget);
            //     return Ok(notebookR);
            // }
            // catch (MyDbException e)
            // {
            //     Console.WriteLine(e);
            //     return Bad("Could not rent the notebook", 500);
            // }
        }

        private Result<EmployeeBudget, RopUseCaseScope> HasEnoughBudget(EmployeeBudget budget, Notebook notebook)
        {
            if (budget.Remaining > notebook.Cost)
            {
               return Result<EmployeeBudget, RopUseCaseScope>.OfOk(budget, RopUseCaseScope.Empty());
            }
            else
            {
                return Result<EmployeeBudget, RopUseCaseScope>.OfFail("Employee has not enough budget for the notebook", RopUseCaseScope.Empty());
            }
        }

        private bool HasNotEnoughBudget(EmployeeBudget budget, Notebook notebook) => budget.Remaining < notebook.Cost;

        private Result<EmployeeBudget, RopUseCaseScope> BudgetForEmployee(EmployeeId eId)
        {
            return _budget.FindById(eId).AsNullable("Budget does not exist", RopUseCaseScope.Empty());
        }

        private Result<Notebook, RopUseCaseScope> FirstNotebookOfType(NotebookType type)
        {
            return _inventory
                .FindNotebooksByType(type)
                .FirstOrDefault(IsAvailable)
                .AsNullable("No Notebook of desired type is available", RopUseCaseScope.Empty());
        }

        private Result<Employee, RopUseCaseScope> FindEmployee(EmployeeId eId)
        {
            return _employees.FindById(eId).AsNullable("Employee does not exist", RopUseCaseScope.Empty());
        }

        private Result<Employee, RopUseCaseScope> HasNoExistingNotebook(Employee employee)
            => employee.NotebookId switch
            {
                null => Result<Employee, RopUseCaseScope>.OfFail("Already has a notebook", RopUseCaseScope.Empty()),
                _ => Result<Employee, RopUseCaseScope>.OfOk(employee, RopUseCaseScope.Empty())
            };

        private EmployeeBudget RentNotebook(Employee employee, EmployeeBudget budget, Notebook notebook)
        {
            // realistically we'd need some form of transaction/rollback here
            _employees.Store(employee with{NotebookId = notebook.Id});
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


        private bool IsAvailable(Notebook notebook) => notebook.Status == NotebookServiceStatus.Available;
    }
}