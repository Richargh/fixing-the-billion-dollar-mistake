using Richargh.BillionDollar.Classic.Common.Entity;

namespace Richargh.BillionDollar.Classic
{
    public class Notebook : IEntity<NotebookId>
    {
        public NotebookId Id { get; }
        public NotebookType NotebookType { get; }
        public string Maker { get; }
        public string Model { get; }
        
        public Notebook(NotebookId id, NotebookType notebookType, string maker, string model)
        {
            Id = id;
            NotebookType = notebookType;
            Maker = maker;
            Model = model;
        }
    }
}