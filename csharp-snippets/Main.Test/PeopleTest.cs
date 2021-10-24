using FluentAssertions;
using Xunit;

namespace Richargh.BillionDollar.Main.Test
{
    public class PeopleTest
    {
        [Fact(DisplayName="Should find nothing when AddressBook is empty")]
        public void ShouldFindNothing()
        {
            // given
            var testee = new People();
            // when
            var result = testee.FindById(new PersonId("1"));
            // then
            result.Should().BeNull();
        }
        
        [Fact(DisplayName="Should find person when in AddressBook")]
        public void ShouldFindPerson()
        {
            // given
            var person = new Person(new PersonId("1"), "Fiona");
            var testee = new People(person);
            // when
            var result = testee.FindById(person.Id);
            // then
            result.Should().BeEquivalentTo(person);
        }
    }
}