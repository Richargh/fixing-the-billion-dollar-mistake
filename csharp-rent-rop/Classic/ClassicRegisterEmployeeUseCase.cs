using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Web;
using static Richargh.BillionDollar.Classic.Common.Web.Responses;

namespace Richargh.BillionDollar.Classic
{
    public class ClassicRegisterEmployeeUseCase : IRegisterEmployeeUseCase
    {
        private readonly Employees _employees;
        private readonly IEmailProvider _emailProvider;

        public ClassicRegisterEmployeeUseCase(Employees employees, IEmailProvider emailProvider)
        {
            _employees = employees;
            _emailProvider = emailProvider;
        }

        public IResponse RegisterEmployee(Request request)
        {
            var employee = DtoMapper.EmployeeFromBody(request.Body);
            if (employee is null)
            {
                return Bad(Status.BadRequest, "", "Employee invalid");
            }

            if (EmailIsNotUnique(employee))
            {
                return Bad(Status.BadRequest, "", "Employee invalid");
            }
            StoreEmployee(employee);
            try
            {
                EmailEmployee(employee);
            }
            catch (EmailAddressUnknownException)
            {
                return Bad(Status.BadRequest, "", "EmailAddress invalid");
            }
            
            return Good(200);
        }

        private bool EmailIsNotUnique(Employee employee) 
            => _employees.FindByEmail(employee.EmailAddress) is not null;

        private void StoreEmployee(Employee employee)
        {
            _employees.Store(employee);
        }
        
        private void EmailEmployee(Employee employee)
        {
            _emailProvider.SendEmail(
                employee.EmailAddress, 
                "Welcome", 
                "You are now registered.");
        }
        
    }
}