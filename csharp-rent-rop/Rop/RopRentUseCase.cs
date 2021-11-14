using System.Linq;
using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Rop;
using Richargh.BillionDollar.Classic.Common.Web;
using static Richargh.BillionDollar.Classic.Common.Rop.Results;
using static Richargh.BillionDollar.Classic.Common.Web.Responses;

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
            var employee = FindEmployee(eId)
                .ThenTry(HasNoExistingNotebook);
            var notebook = FirstNotebookOfType(type);

            return BudgetForEmployee(eId)
                .ThenTry2(notebook, HasEnoughBudget)
                .Then3(employee, notebook, RentNotebook)
                .ThenTry3(employee, notebook, NotifyOfRent)
                .Finally3(employee, notebook, CreateOkResponse, CreateBadResponse);
        }

        private Result<EmployeeBudget> HasEnoughBudget(EmployeeBudget budget, Notebook notebook)
        {
            if (budget.Remaining > notebook.Cost)
            {
               return Ok(budget);
            }
            else
            {
                return Fail<EmployeeBudget>(R.Budget.NotEnoughBudget());
            }
        }

        private Result<EmployeeBudget> BudgetForEmployee(EmployeeId eId)
        {
            return _budget.FindById(eId).AsResult(R.Budget.EmployeeBudgetNotFound());
        }

        private Result<Notebook> FirstNotebookOfType(NotebookType type)
        {
            return _inventory
                .FindNotebooksByType(type)
                .FirstOrDefault(IsAvailable)
                .AsResult(R.Budget.RentNotebook.NoNotebookOfType());
        }

        private Result<Employee> FindEmployee(EmployeeId eId)
        {
            return _employees.FindById(eId).AsResult(R.Employee.EmployeeNotFound());
        }

        private Result<Employee> HasNoExistingNotebook(Employee employee)
            => employee.NotebookId switch
            {
                null => Ok(employee),
                _ => Fail<Employee>(R.Budget.RentNotebook.EmployeeAlreadyHasNotebook())
            };

        private EmployeeBudget RentNotebook(EmployeeBudget budget, Employee employee, Notebook notebook)
        {
            // realistically we'd need some form of transaction/rollback here
            _employees.Store(employee with{NotebookId = notebook.Id});
            _inventory.Store(notebook with{Status = NotebookServiceStatus.Rented});
            var remainingBudget = budget with{Remaining = budget.Remaining - notebook.Cost};
            _budget.Store(remainingBudget);
            return remainingBudget;
        }

        private Result<EmployeeBudget> NotifyOfRent(EmployeeBudget remainingBudget, Employee employee, Notebook notebook)
        {
            var subject = $"Rented '{notebook.Maker} {notebook.Model}' for you";
            var text = $"Your new budget is {remainingBudget.Remaining.Amount}";
            try
            {
                _emailProvider.SendEmail(employee.Id, subject, text);
                return Ok(remainingBudget);
            }
            catch (EmailAddressUnknownException)
            {
                return Fail<EmployeeBudget>(R.Budget.RentNotebook.EmployeeEmailUnknown());
            }
        }


        private bool IsAvailable(Notebook notebook) => notebook.Status == NotebookServiceStatus.Available;
        
        private IResponse CreateOkResponse(EmployeeBudget budget, Employee employee, Notebook notebook) 
            => Good(employee, Status.Ok);

        private IResponse CreateBadResponse(Failure failure) 
            => Bad(failure.Status, failure.Code, failure.Message);
    }
}