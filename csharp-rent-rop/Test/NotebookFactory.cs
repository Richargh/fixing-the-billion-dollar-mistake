using Richargh.BillionDollar.Classic;
using static Richargh.BillionDollar.Classic.NotebookServiceStatus;
using static Richargh.BillionDollar.Classic.NotebookType;

namespace Richargh.BillionDollar.Test
{
    public static class NotebookFactory
    {
        public static Notebook AnAvailableNotebook(string id = "1", NotebookType type = Performance) => 
            new(new NotebookId(id), type, "Bell", "GT Banana", new Money(1_000), Available); 
    }
}