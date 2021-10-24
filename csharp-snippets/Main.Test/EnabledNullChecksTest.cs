using FluentAssertions;
using Legacy;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class EnabledNullChecksTest
    {
        [Fact(DisplayName="Should produce a result in code where we enabled null checks")]
        public void ShouldProduceNullReferenceException()
        {
            // given
            // when
            var result = EnabledNullChecks.WorkWithNullSafety();
            // then
            result.Should().BeNull();
        }
    }
}