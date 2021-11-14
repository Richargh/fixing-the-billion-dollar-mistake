using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Classic
{
    public static class R
    {
        public static class Employee
        {
            public static Failure EmployeeIdInvalid() => new(Status.BadRequest, "1_0_1", "EmployeeId invalid");
            public static Failure EmployeeNotFound() => new(Status.NotFound, "1_0_2", "Employee not found");


            public static class ChangeAddress
            {
                public static Failure AddressInvalid(string message) => new(Status.BadRequest, "1_1_1", message);

                public static Failure EmployeeEmailUnknown() => new(Status.BadRequest, "1_1_2", "Employee Email unknown");
            }

        }
        public static class Budget
        {
            
            public static Failure EmployeeBudgetNotFound() => new(Status.NotFound, "2_0_1", "Employee Budget not found");
            public static Failure NotEnoughBudget() => new(Status.BadRequest, "2_0_2", "Employee has not enough budget for the notebook");

            public static class RentNotebook
            {
                public static Failure NoNotebookOfType() => new(Status.BadRequest, "2_1_1", "No Notebook of desired type is available");
                public static Failure EmployeeAlreadyHasNotebook() => new(Status.BadRequest, "2_1_2", "No Notebook of desired type is available");
                public static Failure EmployeeEmailUnknown() => new(Status.BadRequest, "2_1_3", "Employee Email unknown");
            }
        }
    }
}