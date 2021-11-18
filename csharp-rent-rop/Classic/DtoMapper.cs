using Newtonsoft.Json;

namespace Richargh.BillionDollar.Classic
{
    public static class DtoMapper
    {
        public static Employee? EmployeeFromBody(string requestBody)
        {
            var dto = JsonConvert.DeserializeObject<EmployeeDto>(requestBody);
            return EmployeeFromBody(dto);
        }
        
        public static Employee? EmployeeFromBody(EmployeeDto dto)
        {
            var address = AddressFromDto(dto.address);
            if (string.IsNullOrWhiteSpace(dto.id))
                return null;
            if (string.IsNullOrWhiteSpace(dto.name))
                return null;
            if (dto.email is not null && string.IsNullOrWhiteSpace(dto.email))
                return null;
            if (address is null)
                return null;

            return new Employee(
                new EmployeeId(dto.id),
                new Name(dto.name),
                new EmailAddress(dto.email!),
                address,
                null);
        }
        
        public static Address? AddressFromBody(string requestBody)
        {
            var dto = JsonConvert.DeserializeObject<AddressDto>(requestBody);
            return AddressFromDto(dto);
        }
        
        public static Address? AddressFromDto(AddressDto? dto)
        {
            if (string.IsNullOrWhiteSpace(dto?.town))
                return null;
            if (dto.street is not null && string.IsNullOrWhiteSpace(dto.street))
                return null;

            return new Address(
                new Town(dto.town), 
                dto.street is null ? null : new Street(dto.street));
        }
    }
}