using Richargh.BillionDollar.Classic.Common;
using Richargh.BillionDollar.Classic.Common.Error;
using Richargh.BillionDollar.Classic.Common.Web;
using static Richargh.BillionDollar.Classic.Common.Web.Responses;

namespace Richargh.BillionDollar.Classic
{
    public class ClassicCalculatePriceUseCase : ICalculatePriceUseCase
    {
        private readonly EmployeeBenefits _benefits;
        private readonly IEmailProvider _emailProvider;

        public ClassicCalculatePriceUseCase(EmployeeBenefits benefits, IEmailProvider emailProvider)
        {
            _benefits = benefits;
            _emailProvider = emailProvider;
        }

        public IResponse CalculatePriceFor(EmployeeId employeeId, NotebookType notebookType)
        {
            var basePrice = notebookType switch
            {
                NotebookType.Performance => new Money(2000),
                NotebookType.Office => new Money(1000),
                _ => null
            };
            if (basePrice is null)
            {
                return Bad(Status.BadRequest, "", "Unknown Notebook Type");
            }
            var benefit = _benefits.FindById(employeeId);
            if (benefit is null)
            {
                return Bad(Status.BadRequest, "", "Employee does not have any benfits");
            }

            if (benefit.WithCompanyFor < 2.Months())
            {
                return Bad(Status.BadRequest, "", "Employee does not get a notebook yet");
            }
            var price = ApplyLengthOfStayBonus(basePrice, benefit);
            
            try
            {
                EmailEmployee(employeeId, price);
            }
            catch (EmailAddressUnknownException)
            {
                return Bad(Status.BadRequest, "", "EmailAddress invalid");
            }
            return Good(200);
        }

        private Money ApplyLengthOfStayBonus(Money price, EmployeeBenefit benefit)
        {
            if (benefit.WithCompanyFor > 24.Months())
                return price - new Money(600);
            if (benefit.WithCompanyFor > 12.Months())
                return price - new Money(400);
            if (benefit.WithCompanyFor > 6.Months())
                return price - new Money(200);

            return price;
        }
        
        private void EmailEmployee(EmployeeId employeeId, Money price)
        {
            _emailProvider.SendEmail(
                employeeId, 
                "Price for notebook", 
                $"Should you choose to accept this notebook, it would cost you {price}");
        }
    }
}