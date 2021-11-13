namespace Richargh.BillionDollar.Classic
{
    public record EmailAddress(string RawValue){
        public override string ToString() => RawValue;
    }
}