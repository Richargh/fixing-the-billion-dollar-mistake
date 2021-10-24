// we can turn on null checks for selected files
#nullable enable

namespace Richargh.BillionDollar.Legacy
{
    public class EnabledNullChecks
    {
        public static int? WorkWithNullSafety()
        {
            string? name = GuessName();
            return name?.Length;
        }

        private static string? GuessName()
        {
            // we would receive a warning that this is null,
            // if we had not already changed the method return type to nullable
            return null;
        }
    }
}