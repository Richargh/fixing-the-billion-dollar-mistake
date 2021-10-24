using System;
using FluentAssertions;
using Legacy;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class UsesLegacyCodeTest
    {
        [Fact(DisplayName="Should produce NullReferenceException in code because Notebook maker is not set")]
        public void ShouldProduceNullReferenceException()
        {
            // given
            var employee = new Employee
            {
                Id = new EmployeeId("1"),
                Name = "Jon"
            };
            var addressBook = new Company(employee);
            var testee = new UsesLegacyCode(addressBook);
            // when
            Action act = () => testee.FindNotebookMaker(employee.Id);
            // then
            act.Should().Throw<NullReferenceException>();
        }
    }
}