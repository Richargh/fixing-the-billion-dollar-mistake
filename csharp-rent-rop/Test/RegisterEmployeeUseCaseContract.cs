using System;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Newtonsoft.Json;
using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common.Web;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public abstract class RegisterEmployeeUseCaseContract
    {
        private readonly Func<Employees, IEmailProvider, IRegisterEmployeeUseCase> _createTestee;

        public RegisterEmployeeUseCaseContract(Func<Employees, IEmailProvider, IRegisterEmployeeUseCase> createTestee)
        {
            _createTestee = createTestee;
        }

        [Fact(DisplayName="registering an employee should be possible, when employee is valid")]
        public void HappyCase()
        {
            // given
            var employeeDto = EmployeeDtoFactory.AnEmployee();
            var json = JsonConvert.SerializeObject(employeeDto);
            var testee = _createTestee(new Employees(), new LoggingEmailProvider());
            // when
            var result = testee.RegisterEmployee(new Request(new Path("/employees"), json));
            // then
            using (new AssertionScope())
            {
                result.Should().BeOfType<GoodResponse>();
            }
        }
        
        [Fact(DisplayName="when registering an employee is possible, an email should be sent to the employee")]
        public void EmailInHappyCase()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmailAddress>(), It.IsAny<string>(), It.IsAny<string>()));
            var employeeDto = EmployeeDtoFactory.AnEmployee();
            var json = JsonConvert.SerializeObject(employeeDto);
            var testee = _createTestee(new Employees(), mockEmailProvider.Object);
            // when
            var result = testee.RegisterEmployee(new Request(new Path("/employees"), json));
            // then
            mockEmailProvider.Verify(mock =>
                mock.SendEmail(It.IsAny<EmailAddress>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
        
        [Fact(DisplayName="registering an employee should be impossible, when json is invalid")]
        public void InvalidJson()
        {
            // given
            var json = "{}";
            var testee = _createTestee(new Employees(), new LoggingEmailProvider());
            // when
            var result = testee.RegisterEmployee(new Request(new Path("/employees"), json));
            // then
            result.Should().BeOfType<BadResponse>();
        }
        
        [Fact(DisplayName="registering an employee should be impossible, when email is already used")]
        public void NotUniqueEmail()
        {
            // given
            var employeeDto = EmployeeDtoFactory.AnEmployee(id: "2", email:"1st@company.lt");
            var json = JsonConvert.SerializeObject(employeeDto);
            var existingEmployee = EmployeeFactory.AnEmployeeWithoutANotebook(id: "1", email: "1st@company.lt");
            var testee = _createTestee(
                new Employees(existingEmployee), new LoggingEmailProvider());
            // when
            var result = testee.RegisterEmployee(new Request(new Path("/employees"), json));
            // then
            result.Should().BeOfType<BadResponse>();
        }
    }
}