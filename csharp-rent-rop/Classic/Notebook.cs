using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public record Notebook(
        NotebookId Id, 
        NotebookType NotebookType, 
        string Maker, string Model, 
        Money Cost,
        NotebookServiceStatus Status) : IEntity<NotebookId>;
}