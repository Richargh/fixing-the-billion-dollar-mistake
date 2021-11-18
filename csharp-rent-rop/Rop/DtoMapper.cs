using Newtonsoft.Json;
using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Rop;
using static Richargh.BillionDollar.Classic.Common.Rop.Results;

namespace Richargh.BillionDollar.Rop
{
    public static class DtoMapper
    {
        public static Result<Employee> EmployeeFromBody(string requestBody)
        {
            return JsonConvert.DeserializeObject<EmployeeDto>(requestBody)
                .AsResult(new Failure(Status.BadRequest, "", "Could not deserialize to dto"))
                .ThenTry(EmployeeFromDto);
        }
        
        public static Result<Employee> EmployeeFromDto(EmployeeDto dto)
        {
            return AddressFromDto(dto.address)
                .ThenTryDo(
                    _ => string.IsNullOrWhiteSpace(dto.id),
                    () => new Failure(Status.BadRequest, "", "Missing id field in Employee"))
                .ThenTryDo(
                    _ => string.IsNullOrWhiteSpace(dto.name),
                    () => new Failure(Status.BadRequest, "", "Missing name field in Employee"))
                .ThenTryDo(
                    _ => dto.email is not null && string.IsNullOrWhiteSpace(dto.email),
                    () => new Failure(Status.BadRequest, "", "When present, email field must not be empty"))
                .Then(address => new Employee(
                    new EmployeeId(dto.id),
                    new Name(dto.name),
                    new EmailAddress(dto.email!),
                    address,
                    null));
        }
        
        public static Result<Address> AddressFromBody(string requestBody)
        {
            return JsonConvert.DeserializeObject<AddressDto>(requestBody)
                .AsResult(new Failure(Status.BadRequest, "", "Could not deserialize to dto"))
                .ThenTry(AddressFromDto);
        }
        
        public static Result<Address> AddressFromDto(AddressDto? dto)
        {
            if (string.IsNullOrWhiteSpace(dto?.town))
                return Fail<Address>(R.Employee.ChangeAddress.AddressInvalid("Missing town field in Address"));
            if (dto.street is not null && string.IsNullOrWhiteSpace(dto.street))
                return Fail<Address>(R.Employee.ChangeAddress.AddressInvalid("When present, street field must not be empty"));

            return Ok(new Address(
                new Town(dto.town), 
                dto.street is null ? null : new Street(dto.street)));
        }
    }
}