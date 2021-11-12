namespace Richargh.BillionDollar.Classic
{
    public record Email(string RawValue){
        public override string ToString() => RawValue;
    }
}