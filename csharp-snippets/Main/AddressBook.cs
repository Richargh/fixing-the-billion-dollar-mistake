using System.Collections.Generic;
using Richargh.BillionDollar.Repo;

namespace Richargh.BillionDollar
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