namespace Richargh.BillionDollar.Legacy
{
    public class Employee
    {

        public EmployeeId Id { get;  }
        public string Name { get; }
        public Notebook Notebook { get; set; }
        
        public Employee(EmployeeId id, string name, Notebook notebook)
        {
            Id = id;
            Name = name;
            Notebook = notebook;
        }
        
    }
}
