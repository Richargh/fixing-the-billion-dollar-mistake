using System;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common.Web;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public abstract class ChangeAddressUseCaseContract
    {
        private readonly Func<Employees, IEmailProvider, IChangeAddressUseCase> _createTestee;

        public ChangeAddressUseCaseContract(Func<Employees, IEmailProvider, IChangeAddressUseCase> createTestee)
        {
            _createTestee = createTestee;
        }

        [Fact(DisplayName="changing an address should be possible, when request valid and employee exists")]
        public void HappyCase()
        {
            // given
            var address = @"{""town"":""Klaipėda"", ""street"":""Aukštoji""}";
            var expectedAddress = new Address(new Town("Klaipėda"), new Street("Aukštoji"));
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var request = new Request(
                new Path("employees/1/changeAddress", ("employeeId", employee.Id.RawValue)),
                address);
            var employees = new Employees(employee);
            
            var testee = _createTestee(employees, new LoggingEmailProvider());
            // when
            var result = testee.ChangeAddress(request);
            // then
            using (new AssertionScope())
            {
                result.Should().BeOfType<OkResponse>();
                employees.FindById(employee.Id)!.Address.Should().Be(expectedAddress);
            }
        }
        
        [Fact(DisplayName="when renting is possible, an email should be sent to the employee")]
        public void EmailInHappyCase()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmailAddress>(), It.IsAny<string>(), It.IsAny<string>()));
            var address = @"{""town"":""Klaipėda"", ""street"":""Aukštoji""}";
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var request = new Request(
                new Path("employees/1/changeAddress", ("employeeId", employee.Id.RawValue)),
                address);
            
            var testee = _createTestee(new Employees(employee), mockEmailProvider.Object);
            // when
            testee.ChangeAddress(request);
            // then
            mockEmailProvider.Verify(mock =>
                mock.SendEmail(It.IsAny<EmailAddress>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        
        [Fact(DisplayName="change address should be impossible, when employee does not exist")]
        public void NoEmployee()
        {
            // given
            var address = @"{""town"":""Klaipėda"", ""street"":""Aukštoji""}";
            var request = new Request(
                new Path("employees/1/changeAddress", ("employeeId", "1")),
                address);
            var testee = _createTestee(new Employees(), new LoggingEmailProvider());
            // when
            var result = testee.ChangeAddress(request);
            // then
            using (new AssertionScope())
            {
                result.Should().BeOfType<BadResponse>();
            }
        }
        
        [Fact(DisplayName="when change address is impossible, no email should be sent")]
        public void NoEmail()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmailAddress>(), It.IsAny<string>(), It.IsAny<string>()));
            var address = @"{""town"":""Klaipėda"", ""street"":""Aukštoji""}";
            var request = new Request(
                new Path("employees/1/changeAddress", ("employeeId", "1")),
                address);
            var testee = _createTestee(new Employees(), mockEmailProvider.Object);
            // when
            testee.ChangeAddress(request);
            // then
            
            mockEmailProvider.Verify(mock =>
                mock.SendEmail(It.IsAny<EmailAddress>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}