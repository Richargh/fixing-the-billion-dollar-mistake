namespace Richargh.BillionDollar.Classic
{
    public record NotebookId(string RawValue)
    {
        public override string ToString() => RawValue;
    }
}