using Newtonsoft.Json;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Web;

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
                return new BadResponse(400, "EmployeeId invalid");
            }
            var employee = FindEmployee(employeeId);
            if (employee is null)
            {
                return new BadResponse(400, "Employee not found");
            }
            var address = AddressFromBody(request.Body);
            if (address is null)
            {
                return new BadResponse(400, "Address invalid");
            }
            employee = employee.ChangeAddress(address);
            
            StoreEmployee(employee);
            try
            {
                EmailEmployee(employee);
            }
            catch (EmailAddressUnknownException)
            {
                return new BadResponse(400, "EmailAddress invalid");
            }
            return new OkResponse(200);
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

        private Address? AddressFromBody(string requestBody)
        {
            var dto = JsonConvert.DeserializeObject<AddressDto>(requestBody);
            if (string.IsNullOrWhiteSpace(dto.town))
                return null;
            if (dto.street is not null && string.IsNullOrWhiteSpace(dto.street))
                return null;

            return new Address(
                new Town(dto.town), 
                dto.street is null ? null : new Street(dto.street));
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