namespace Richargh.BillionDollar.Classic
{
    public record Name(string RawValue){
        public override string ToString() => RawValue;
    }
}