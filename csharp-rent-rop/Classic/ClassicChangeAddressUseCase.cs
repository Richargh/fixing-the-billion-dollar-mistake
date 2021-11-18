using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Web;
using static Richargh.BillionDollar.Classic.Common.Web.Responses;

namespace Richargh.BillionDollar.Classic
{
    public class ClassicChangeAddressUseCase : IChangeAddressUseCase
    {
        private readonly Employees _employees;
        private readonly IEmailProvider _emailProvider;

        public ClassicChangeAddressUseCase(Employees employees, IEmailProvider emailProvider)
        {
            _employees = employees;
            _emailProvider = emailProvider;
        }
        
        public IResponse ChangeAddress(Request request)
        {
            var employeeId = EmployeeIdFromPath(request.Path);
            if (employeeId is null)
            {
                return Bad(Status.BadRequest, "", "EmployeeId invalid");
            }
            var employee = FindEmployee(employeeId);
            if (employee is null)
            {
                return Bad(Status.BadRequest, "", "Employee not found");
            }
            var address = DtoMapper.AddressFromBody(request.Body);
            if (address is null)
            {
                return Bad(Status.BadRequest, "", "Address invalid");
            }
            employee = employee.ChangeAddress(address);
            
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

        private void StoreEmployee(Employee employee)
        {
            _employees.Store(employee);
        }

        private Employee? FindEmployee(EmployeeId employeeId) => _employees.FindById(employeeId);

        private void EmailEmployee(Employee employee)
        {
            _emailProvider.SendEmail(
                employee.EmailAddress, 
                "Address changed", 
                "We changed your address. Please notify us if this was not you.");
        }

        private EmployeeId? EmployeeIdFromPath(Path path)
        {
            var rawId = path["employeeId"];
            return string.IsNullOrWhiteSpace(rawId)
                ? null
                : new EmployeeId(rawId);
        }

    }
}