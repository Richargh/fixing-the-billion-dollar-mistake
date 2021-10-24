using FluentAssertions;
using Richargh.BillionDollar.Legacy;
using Xunit;

namespace Richargh.BillionDollar.Main.Test
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