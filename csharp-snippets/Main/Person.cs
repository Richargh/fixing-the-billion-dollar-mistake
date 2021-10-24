using Richargh.BillionDollar.Repo;

namespace Richargh.BillionDollar
{
    public class Person : IEntity<PersonId>
    {
        public PersonId Id { get;  }
        public string Name { get; }
        
        public Person(PersonId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}