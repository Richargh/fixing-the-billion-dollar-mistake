using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class EmployeeFactory
    {
        
        public static Employee AnEmployeeWithoutANotebook(string id = "1") => 
            new(new EmployeeId(id), "Alex", NotebookId:null); 
    }
}