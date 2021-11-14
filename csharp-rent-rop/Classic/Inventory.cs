using System.Collections.Generic;
using System.Linq;
using Richargh.BillionDollar.Classic.Common.Entity;
using Richargh.BillionDollar.Classic.Common.Lang;

namespace Richargh.BillionDollar.Classic
{
    public class Inventory
    {
        private readonly SimpleRepository<NotebookId, Notebook> _notebooks;
        private readonly Dictionary<NotebookType, ISet<NotebookId>> _notebookTypes;
        
        public Inventory(params Notebook[] notebooks)
        {
            _notebooks = new SimpleRepository<NotebookId, Notebook>();
            _notebookTypes = new Dictionary<NotebookType, ISet<NotebookId>>();
            foreach (var notebook in notebooks)
            {
                Store(notebook);
            }
        }
        
        public Notebook? FindNotebookById(NotebookId id)
        {
            return _notebooks.FindById(id);
        }
        
        public IEnumerable<Notebook> FindNotebooksByType(NotebookType type)
        {
            var idsForType = _notebookTypes.GetValueOrDefault(type) ?? new HashSet<NotebookId>();
            return idsForType.Select(id => _notebooks.FindById(id)).WhereNotNull();
        }

        public void Store(Notebook notebook)
        {
            _notebooks.Put(notebook);
            if (!_notebookTypes.ContainsKey(notebook.NotebookType)){
                _notebookTypes[notebook.NotebookType] = new HashSet<NotebookId>();
            }
            _notebookTypes[notebook.NotebookType].Add(notebook.Id);
        }
    }
}