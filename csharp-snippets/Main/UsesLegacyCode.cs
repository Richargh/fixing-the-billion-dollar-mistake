using Legacy;

namespace Richargh.BillionDollar
{
    public class UsesLegacyCode
    {
        private readonly Register _register;

        public UsesLegacyCode(Register register)
        {
            _register = register;
        }
        
        public string? FindNotebookMaker(string id)
        {
            var person = _register.FindById(id);
            // we guard against person being null but forget about the object properties
            if (person is null)
                return null;
            
            // compiles just fine even though Notebook is not necessarily set 
            return person.Notebook.Maker;
        }
    }
}