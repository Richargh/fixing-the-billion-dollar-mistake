using Richargh.BillionDollar.Classic;

namespace Richargh.BillionDollar.Test
{
    public class EmployeeFactory
    {
        
        public static Employee AnEmployeeWithoutANotebook(string id = "1", string email = "foo@bar.de") => new(
                new EmployeeId(id), 
                new Name("Alex"), 
                new EmailAddress(email), 
                new Address(new Town("Vilnius"), new Street("Konstitucijos Av. 20")),
                NotebookId:null); 
    }
}