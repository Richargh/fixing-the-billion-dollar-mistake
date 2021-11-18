using Newtonsoft.Json;
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
    public class RopChangeAddressUseCase : IChangeAddressUseCase
    {
        private readonly Employees _employees;
        private readonly IEmailProvider _emailProvider;

        public RopChangeAddressUseCase(Employees employees, IEmailProvider emailProvider)
        {
            _employees = employees;
            _emailProvider = emailProvider;
        }
        
        public IResponse ChangeAddress(Request request)
        {
            return EmployeeIdFromPath(request.Path)
                .ThenTry(FindEmployee)
                .ThenTryToPair(_ => AddressFromBody(request.Body))
                .ThenUnpaired((employee, address) => employee.ChangeAddress(address))
                .ThenDo(StoreEmployee)
                .ThenTry(EmailEmployee)
                .Finally(CreateOkResponse, CreateBadResponse);
        }

        private IResponse CreateOkResponse(Employee employee) => Good(employee, Status.Ok);

        private IResponse CreateBadResponse(Failure failure) => Bad(failure.Status, failure.Code, failure.Message);

        private void StoreEmployee(Employee employee)
        {
            _employees.Store(employee);
        }

        private Result<EmployeeId> EmployeeIdFromPath(Path path)
        {
            var rawId = path["employeeId"];
            return string.IsNullOrWhiteSpace(rawId)
                ? Fail<EmployeeId>(R.Employee.EmployeeIdInvalid())
                : Ok(new EmployeeId(rawId));
        }

        private Result<Employee> FindEmployee(EmployeeId employeeId)
            => _employees.FindById(employeeId).AsResult(R.Employee.EmployeeNotFound());

        private Result<Employee> EmailEmployee(Employee employee)
        {
            try
            {
                _emailProvider.SendEmail(
                    employee.EmailAddress,
                    "Address changed",
                    "We changed your address. Please notify us if this was not you.");
                return Ok(employee);
            }
            catch (EmailAddressUnknownException)
            {
                return Fail<Employee>(R.Employee.ChangeAddress.EmployeeEmailUnknown());
            }
        }
    }
}