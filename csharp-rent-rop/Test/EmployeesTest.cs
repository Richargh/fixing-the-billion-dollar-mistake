using FluentAssertions;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class EmployeesTest
    {
        [Fact(DisplayName="Should find nothing when Repository is empty")]
        public void ShouldFindNothing()
        {
            // given
            var testee = new Employees();
            // when
            var result = testee.FindById(new EmployeeId("1"));
            // then
            result.Should().BeNull();
        }
        
        [Fact(DisplayName="Should find employee after we've put her in the Repository")]
        public void ShouldFindEmployeeAfterPut()
        {
            // given
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var testee = new Employees();
            // when
            testee.Store(employee);
            // then
            var result = testee.FindById(employee.Id);
            result.Should().BeEquivalentTo(employee);
        }
        
        [Fact(DisplayName="Should find employee when already in the Repository")]
        public void ShouldFindAlreadyKnownEmployee()
        {
            // given
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var testee = new Employees(employee);
            // when
            var result = testee.FindById(employee.Id);
            // then
            result.Should().BeEquivalentTo(employee);
        }
    }
}