using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class EmployeeFactory
    {
        
        public static Employee AnEmployeeWithoutANotebook(string id = "1") => new(
                new EmployeeId(id), 
                new Name("Alex"), 
                new EmailAddress("foo@bar.de"), 
                new Address(new Town("Vilnius"), new Street("Konstitucijos Av. 20")),
                NotebookId:null); 
    }
}