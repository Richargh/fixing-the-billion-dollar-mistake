using System;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common.Web;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public abstract class CalculatePriceUseCaseContract
    {
        private readonly Func<EmployeeBenefits, IEmailProvider, ICalculatePriceUseCase> _createTestee;

        public CalculatePriceUseCaseContract(Func<EmployeeBenefits, IEmailProvider, ICalculatePriceUseCase> createTestee)
        {
            _createTestee = createTestee;
        }

        [Fact(DisplayName="an employee who has been with the company for three months should get a notebook without reduction")]
        public void HappyCase()
        {
            // given
            var benefit = new EmployeeBenefit(new EmployeeId("1"), new Months(3));
            
            var testee = _createTestee(new EmployeeBenefits(benefit), new LoggingEmailProvider());
            // when
            var result = testee.CalculatePriceFor(benefit.Id, NotebookType.Performance);
            // then
            using (new AssertionScope())
            {
                result.Should().BeOfType<GoodResponse>();
            }
        }
        
        [Fact(DisplayName="when a price is possible, an email should be sent to the employee")]
        public void EmailInHappyCase()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()));
            var benefit = new EmployeeBenefit(new EmployeeId("1"), new Months(3));
            
            var testee = _createTestee(new EmployeeBenefits(benefit), mockEmailProvider.Object);
            // when
            var result = testee.CalculatePriceFor(benefit.Id, NotebookType.Performance);
            // then
            mockEmailProvider.Verify(mock =>
                mock.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        
        [Fact(DisplayName="an employee who has been with the company for less than two months should get no notebook")]
        public void LessThanTwoMonths()
        {
            // given
            var benefit = new EmployeeBenefit(new EmployeeId("1"), new Months(1));
            
            var testee = _createTestee(new EmployeeBenefits(benefit), new LoggingEmailProvider());
            // when
            var result = testee.CalculatePriceFor(benefit.Id, NotebookType.Performance);
            // then
            using (new AssertionScope())
            {
                result.Should().BeOfType<BadResponse>();
            }
        }
        
        [Fact(DisplayName="when price is impossible, no email should be sent")]
        public void NoEmailSent()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()));
            var benefit = new EmployeeBenefit(new EmployeeId("1"), new Months(1));
            
            var testee = _createTestee(new EmployeeBenefits(benefit), new LoggingEmailProvider());
            // when
            var result = testee.CalculatePriceFor(benefit.Id, NotebookType.Performance);
            // then
            mockEmailProvider.Verify(mock =>
                mock.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
        
    }
}