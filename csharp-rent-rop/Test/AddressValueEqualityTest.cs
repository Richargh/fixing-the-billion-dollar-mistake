using FluentAssertions;
using FluentAssertions.Execution;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class AddressValueEqualityTest
    {
        [Fact(DisplayName="Addresses with the same values should be equal")]
        public void SameValues()
        {
            // given
            // when
            var address1 = new Address(new Town("Vilnius"), new Street("Konstitucijos Av. 20"));
            var address2 = new Address(new Town("Vilnius"), new Street("Konstitucijos Av. 20"));
            // then
            using (new AssertionScope())
            {
                (address1 == address2).Should().BeTrue();
                address1.Should().Be(address2);
            }
        }
        
        [Fact(DisplayName="Addresses with different values should be equal")]
        public void DifferentValues()
        {
            // given
            // when
            var address1 = new Address(new Town("Vilnius"), new Street("Konstitucijos Av. 20"));
            var address2 = new Address(new Town("Vilnius"), new Street("Ozo g. 18"));
            // then
            using (new AssertionScope())
            {
                (address1 == address2).Should().BeFalse();
                address1.Should().NotBe(address2);
            }
        }
        
        [Fact(DisplayName="Address should not be equal after non-destructive mutation")]
        public void NonDestructiveMutation()
        {
            // given
            // when
            var address1 = new Address(new Town("Vilnius"), new Street("Konstitucijos Av. 20"));
            var address2 = address1 with {Street = new Street("Ozo g. 18")};
            // then
            using (new AssertionScope())
            {
                (address1 == address2).Should().BeFalse();
                address1.Should().NotBe(address2);
            }
        }
    }
}