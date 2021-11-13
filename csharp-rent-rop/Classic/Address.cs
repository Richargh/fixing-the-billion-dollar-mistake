namespace Richargh.BillionDollar.Classic
{
    public record Address(Town Town, Street? Street){
        public override string ToString() => Town.ToString() + Street?.ToString();
        
    }

    public record Town(string RawValue)
    {
        public override string ToString() => RawValue;
    }

    public record Street(string RawValue)
    {
        public override string ToString() => RawValue;
    }
}