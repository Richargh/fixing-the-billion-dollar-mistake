namespace Richargh.BillionDollar.Classic
{
    public record EmployeeId(string RawValue)
    {
        public override string ToString() => RawValue;
    }
}