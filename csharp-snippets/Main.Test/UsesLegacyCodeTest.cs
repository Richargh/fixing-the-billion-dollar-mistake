using System;
using FluentAssertions;
using Legacy;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class UsesLegacyCodeTest
    {
        [Fact(DisplayName="Should produce NullReferenceException in code where we disabled null checks")]
        public void ShouldProduceNullReferenceException()
        {
            // given
            var addressBook = new Register();
            var testee = new UsesLegacyCode(addressBook);
            // when
            Action act = () => testee.FindNotebookMaker("1");
            // then
            act.Should().Throw<NullReferenceException>();
        }
    }
}