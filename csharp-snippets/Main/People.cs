using System.Collections.Generic;
using Richargh.BillionDollar.Main.Repo;

namespace Richargh.BillionDollar.Main
{
    public class People : GenericRepository<PersonId, Person>
    {
        public People(IEnumerable<Person> people) : base(people)
        {
        }

        public People(params Person[] people) : base(people)
        {
        }
    }
}