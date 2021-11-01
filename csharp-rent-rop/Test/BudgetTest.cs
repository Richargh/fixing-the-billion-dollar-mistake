using FluentAssertions;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class BudgetTest
    {
        [Fact(DisplayName="Should find nothing when Repository is empty")]
        public void ShouldFindNothing()
        {
            // given
            var testee = new Budget();
            // when
            var result = testee.FindById(new EmployeeId("1"));
            // then
            result.Should().BeNull();
        }
        
        [Fact(DisplayName="Should find budget after we've put it into the Repository")]
        public void ShouldFindBudgetAfterPut()
        {
            // given
            var budget = new EmployeeBudget(new EmployeeId("1"), new Money(10));
            var testee = new Budget();
            // when
            testee.Put(budget);
            // then
            var result = testee.FindById(budget.Id);
            result.Should().BeEquivalentTo(budget);
        }
        
        [Fact(DisplayName="Should find budget when it's already in the Repository")]
        public void ShouldFindAlreadyKnownBudget()
        {
            // given
            var budget = new EmployeeBudget(new EmployeeId("1"), new Money(10));
            var testee = new Budget(budget);
            // when
            var result = testee.FindById(budget.Id);
            // then
            result.Should().BeEquivalentTo(budget);
        }
    }
}