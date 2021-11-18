using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Rop;
using Richargh.BillionDollar.Classic.Common.Web;
using static Richargh.BillionDollar.Classic.Common.Rop.Results;
using static Richargh.BillionDollar.Classic.Common.Web.Responses;
using static Richargh.BillionDollar.Rop.DtoMapper;

namespace Richargh.BillionDollar.Rop
{
    public class RopRegisterEmployeeUseCase : IRegisterEmployeeUseCase
    {
        private readonly Employees _employees;
        private readonly IEmailProvider _emailProvider;

        public RopRegisterEmployeeUseCase(Employees employees, IEmailProvider emailProvider)
        {
            _employees = employees;
            _emailProvider = emailProvider;
        }

        public IResponse RegisterEmployee(Request request)
        {
            return EmployeeFromBody(request.Body)
                .ThenTry(CheckEmailIsUnique)
                // if overwrite set, then overwrite existing employee
                .Then(StoreEmployee)
                .ThenTry(EmailEmployee)
                .Finally(CreateOkResponse, CreateBadResponse);
        }

        private Result<Employee> CheckEmailIsUnique(Employee employee) 
            => _employees.FindByEmail(employee.EmailAddress) switch
            {
                null => Ok(employee),
                _ => Fail<Employee>(new Failure(Status.BadRequest, "", "Email must be unique"))
            };

        private Employee StoreEmployee(Employee employee)
        {
            _employees.Store(employee);
            return employee;
        }
        
        private Result<Employee> EmailEmployee(Employee employee)
        {
            try
            {
                _emailProvider.SendEmail(
                    employee.EmailAddress, 
                    "Welcome", 
                    "You are now registered.");
                return Ok(employee);
            }
            catch (EmailAddressUnknownException)
            {
                return Fail<Employee>(R.Employee.ChangeAddress.EmployeeEmailUnknown());
            }
        }

        private IResponse CreateOkResponse(Employee employee) => Good(employee, Status.Ok);

        private IResponse CreateBadResponse(Failure failure) => Bad(failure.Status, failure.Code, failure.Message);
        
    }
}