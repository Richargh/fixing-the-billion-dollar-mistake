using Richargh.BillionDollar.Classic.Common.Web;

namespace Richargh.BillionDollar.Classic
{
    public interface ICalculatePriceUseCase
    {
        public IResponse CalculatePriceFor(EmployeeId employeeId, NotebookType notebookType);
    }
}