using FluentAssertions;
using Richargh.BillionDollar;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class GreeterTest
    {
	[Fact(DisplayName="Greeting should contain passed name")]
        public void ContainsName()
        {
            // given
            var testee = new Greeter();
            // when
	    var result = testee.greet("Ben");
            // then
            result.Should().Be("Hello Ben!");
        }
    }
}
