using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Richargh.BillionDollar.Classic;
using Xunit;

namespace Richargh.BillionDollar.Test
{
    public class ClassicRentUseCaseTest
    {
        [Fact(DisplayName="renting should be possible, when employee has enough budget remaining for notebook")]
        public void HappyCase()
        {
            // given
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var notebook = NotebookFactory.AnAvailableNotebook();
            var budget = new EmployeeBudget(employee.Id, Remaining: notebook.Cost + new Money(1));
            var testee = new ClassicRentUseCase(
                new Inventory(notebook), new Employees(employee), new Budget(budget), new LoggingEmailProvider());
            // when
            var result = testee.Rent(notebook.NotebookType, employee.Id);
            // then
            using (new AssertionScope())
            {
                result.Should().Be(RentResult.Rented);
            }
        }
        
        [Fact(DisplayName="when renting is possible, an email should be sent to the employee")]
        public void EmailInHappyCase()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()));
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var notebook = NotebookFactory.AnAvailableNotebook();
            var budget = new EmployeeBudget(employee.Id, Remaining: notebook.Cost + new Money(1));
            var testee = new ClassicRentUseCase(
                new Inventory(notebook), new Employees(employee), new Budget(budget), mockEmailProvider.Object);
            // when
            var result = testee.Rent(notebook.NotebookType, employee.Id);
            // then
            using (new AssertionScope())
            {
                result.Should().Be(RentResult.Rented);
                mockEmailProvider.Verify(mock =>
                    mock.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            }
        }
        
        [Fact(DisplayName="renting should be impossible, when employee has too little budget remaining for notebook")]
        public void TooLittleBudget()
        {
            // given
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var notebook = NotebookFactory.AnAvailableNotebook();
            var budget = new EmployeeBudget(employee.Id, Remaining: notebook.Cost - new Money(1));
            var testee = new ClassicRentUseCase(
                new Inventory(notebook), new Employees(employee), new Budget(budget), new LoggingEmailProvider());
            // when
            var result = testee.Rent(notebook.NotebookType, employee.Id);
            // then
            result.Should().Be(RentResult.NotRented);
        }
        
        [Fact(DisplayName="renting should be impossible, when employee does not exist")]
        public void NoEmployee()
        {
            // given
            var notebook = NotebookFactory.AnAvailableNotebook();
            var budget = new EmployeeBudget(new EmployeeId("1"), Remaining: notebook.Cost + new Money(1));
            var testee = new ClassicRentUseCase(
                new Inventory(notebook), new Employees(), new Budget(budget), new LoggingEmailProvider());
            // when
            var result = testee.Rent(notebook.NotebookType, budget.Id);
            // then
            result.Should().Be(RentResult.NotRented);
        }
        
        [Fact(DisplayName="renting should be impossible, when no notebook of expected type is available")]
        public void NoNotebook()
        {
            // given
            var employee = EmployeeFactory.AnEmployeeWithoutANotebook();
            var notebook = NotebookFactory.AnAvailableNotebook(type:NotebookType.Performance);
            var budget = new EmployeeBudget(employee.Id, Remaining: notebook.Cost + new Money(1));
            var testee = new ClassicRentUseCase(
                new Inventory(notebook), new Employees(employee), new Budget(budget), new LoggingEmailProvider());
            // when
            var result = testee.Rent(NotebookType.Office, employee.Id);
            // then
            result.Should().Be(RentResult.NotRented);
        }
        
        [Fact(DisplayName="renting should be impossible, when nothing exists")]
        public void NoNothing()
        {
            // given
            var testee = new ClassicRentUseCase(
                new Inventory(), new Employees(), new Budget(), new LoggingEmailProvider());
            // when
            var result = testee.Rent(NotebookType.Performance, new EmployeeId("1"));
            // then
            result.Should().Be(RentResult.NotRented);
        }
        
        [Fact(DisplayName="when renting is impossible, no email should be sent")]
        public void NoEmail()
        {
            // given
            var mockEmailProvider = new Mock<IEmailProvider>();
            mockEmailProvider.Setup(x => x.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()));
            var testee = new ClassicRentUseCase(
                new Inventory(), new Employees(), new Budget(), mockEmailProvider.Object);
            // when
            var result = testee.Rent(NotebookType.Performance, new EmployeeId("1"));
            // then
            mockEmailProvider.Verify(mock =>
                mock.SendEmail(It.IsAny<EmployeeId>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}