// we can turn of null checks for really complex files
#nullable disable

namespace Richargh.BillionDollar
{
    public static class DisabledNullChecks
    {
        public static int WorkWithoutNullSafety()
        {
            string name = GuessName();
            // this access is no longer prevented
            return name.Length;
        }

        private static string GuessName()
        {
            // returning null is allowed
            return null;
        }
    }
}