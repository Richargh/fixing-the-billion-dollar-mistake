using System;
using FluentAssertions;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class DisabledNullChecksTest
    {
        [Fact(DisplayName="Should produce NullReferenceException in code where we disabled null checks")]
        public void ShouldProduceNullReferenceException()
        {
            // given
            // when
            Action act = () => DisabledNullChecks.WorkWithoutNullSafety();
            // then
            act.Should().Throw<NullReferenceException>();
        }
    }
}