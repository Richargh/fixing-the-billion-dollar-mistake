namespace Richargh.BillionDollar.Classic
{
    public static class MonthsExtensions
    {
        public static Months Months(this int rawMonths) => new Months(rawMonths);
    }
}