using System.Collections.Generic;
using Richargh.BillionDollar.Main.Repo;

namespace Richargh.BillionDollar.Main
{
    public class AddressBook : GenericRepository<PersonId, Person>
    {
        public AddressBook(IEnumerable<Person> people) : base(people)
        {
        }

        public AddressBook(params Person[] people) : base(people)
        {
        }
    }
}