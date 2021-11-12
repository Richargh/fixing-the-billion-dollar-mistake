using System.Diagnostics.CodeAnalysis;

namespace Richargh.BillionDollar.Classic
{
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "It's ok for Dtos because they should look like the json.")]
    public record AddressDto(string town, string? street);
}