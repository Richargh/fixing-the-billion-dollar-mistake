using Richargh.BillionDollar.Classic;
using Richargh.BillionDollar.Classic.Common.Web;

namespace Richargh.BillionDollar.Rop
{
    public class RopCalculatePriceUseCase : ICalculatePriceUseCase
    {
        private readonly EmployeeBenefits _benefits;
        private readonly IEmailProvider _emailProvider;

        public RopCalculatePriceUseCase(EmployeeBenefits benefits, IEmailProvider emailProvider)
        {
            _benefits = benefits;
            _emailProvider = emailProvider;
        }
        public IResponse CalculatePriceFor(EmployeeId employeeId, NotebookType notebookType)
        {
            // TODO
            throw new System.NotImplementedException();
        }
    }
}