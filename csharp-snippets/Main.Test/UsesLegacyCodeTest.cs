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
            (
                new EmployeeId("1"),
                "John",
                notebook:null
            );
            var addressBook = new Company(employee);
            var testee = new UsesLegacyCode(addressBook);
            // when
            Action act = () => testee.FindNotebookMaker(employee.Id);
            // then
            act.Should().Throw<NullReferenceException>();
        }
        
        [Fact(DisplayName="Should return the Notebook maker because it is set")]
        public void ShouldReturnMaker()
        {
            // given
            var employee = new Employee
            (
                new EmployeeId("1"),
                "John",
                new Notebook("Bell", "Infinity X Venti Plaid Max")
            );
            var addressBook = new Company(employee);
            var testee = new UsesLegacyCode(addressBook);
            // when
            var result = testee.FindNotebookMaker(employee.Id);
            // then
            result.Should().Be("Bell");
        }
    }
}